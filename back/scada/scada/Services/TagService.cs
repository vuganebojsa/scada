using Microsoft.AspNetCore.SignalR;
using scada.Data;
using scada.DTOS;
using scada.Hubs;
using scada.Interfaces;
using scada.Models;
using System.Text.Json;

namespace scada.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IAlarmRepository _alarmRepository;
        private readonly IHubContext<AlarmsHub, IAlarmHubClient> _alarmsHub;
        private readonly IHubContext<InputTagsHub, IINputTagHubClient> _inputTagsHub;


        public TagService(ITagRepository tagRepository, 
            IAlarmRepository alarmRepository,
            IHubContext<InputTagsHub, IINputTagHubClient> inputTagsHub, IHubContext<AlarmsHub, IAlarmHubClient> alarmsHub)
        {
            _tagRepository = tagRepository;
            _alarmRepository = alarmRepository;
            _inputTagsHub = inputTagsHub;
            _alarmsHub = alarmsHub;
        }

        public async Task<DigitalInputDTO> CreateDigitalInputTag(DigitalInputDTO digitalTagDto)
        {
            return await this._tagRepository.CreateDigitalInputTag(digitalTagDto);
        }

        public async Task<DigitalOutputDTO> CreateDigitalOutputTag(DigitalOutputDTO digitalTagDto)
        {

            return await  this._tagRepository.CreateDigitalOutputTag(digitalTagDto);
        }

        public async Task<bool> DeleteOutTag(int id, string type)
        {
            return await this._tagRepository.DeleteOutTag(id, type);
        }

        public async Task<ICollection<InTagDTO>> GetInTags()
        {
            var tags =await _tagRepository.GetInTags();

            var newTags = new List<InTagDTO>();
            foreach(Tag tag in tags)
            {
                if (tag is AnalogInput)
                    newTags.Add(new InTagDTO(tag.id, tag.tagName, tag.currentValue, (tag as AnalogInput).OnOffScan, "AnalogInput"));
                else
                    newTags.Add(new InTagDTO(tag.id, tag.tagName, tag.currentValue, (tag as DigitalInput).OnOffScan, "DigitalInput"));

            }

            return newTags;
        }

        public async Task<ICollection<OutTagDTO>> GetOutTags()
        {
            var  tags =await this._tagRepository.GetOutTags();

            var newTags = new List<OutTagDTO>();
            foreach(Tag tag in tags)
            {
                if (tag is AnalogOutput)
                    newTags.Add(new OutTagDTO(tag.id, tag.tagName, tag.currentValue, "AnalogOutput"));
                else
                    newTags.Add(new OutTagDTO(tag.id, tag.tagName, tag.currentValue, "DigitalOutput"));

            }

            return newTags;
        }


        public async Task<AnalogOutputDTO> CreateOutputTag(AnalogOutputDTO analogOutputDTO)
        {
            return await this._tagRepository.CreateAnalogOutput(analogOutputDTO);
        }

        public async Task<bool> SetScan(int id, string type, bool isOn)
        {
            return await this._tagRepository.SetScan(id, type, isOn);
        }

        public async Task< bool> SetValue(int id, string type, int value)
        {
            return await this._tagRepository.SetValue(id, type, value);
        }

        public async Task<AnalogInput> createAnalogInput(AnalogInputDTO analogTagDto)
        {
            
            return await this._tagRepository.createAnalogInput(analogTagDto);

        }

        public async Task<bool> DeleteInTag(int id, string type)
        {
            return await this._tagRepository.DeleteInTag(id, type);
        }

        public async Task StartSimulation()
        {
            var analogInputs =await this._tagRepository.GetAnalogInputTags();
            var digitalInputs =await this._tagRepository.GetDigitalInputTags();

            foreach(var tag in analogInputs)
            {
                RunAnalogThread(tag);
            }
            foreach(var tag in digitalInputs)
            {

                RunDigitalThread(tag);
            }
        }

        private void RunAnalogThread(AnalogInput tag)
        {
            new Thread( async () =>
            {

                Console.WriteLine(tag.id);
                Thread.CurrentThread.IsBackground = true;
                while (true)
                {
                    float currValue = tag.currentValue;
                    float newValue = SimulationDriver.ReturnValue(tag.IOAddress);

                    if (newValue > tag.HighLimit) newValue = (float)tag.HighLimit;
                    else if (newValue < tag.LowLimit) newValue = (float)tag.LowLimit;

                    // value setting
                    Thread.Sleep((int)(tag.ScanTime * 1000));

                    if (currValue == newValue) continue;

                    PastTagValues pt = new PastTagValues(tag, currValue, tag.IOAddress);

                   
                        tag.currentValue = newValue;

                        await _tagRepository.CreatePastTagValue(pt);
                        await _tagRepository.UpdateAnalogInput(tag);


                    // alarms

                    var alarms = await this._alarmRepository.GetAllAlarmsById(tag.id);

                    foreach (var alarm in alarms)
                    {
                        if (alarm.Type.ToLower() == "high")
                        {
                            if (newValue > alarm.threshHold)
                            {
                                // new alarm activation, insert to db
                                AlarmActivation aa = new AlarmActivation(alarm);
                                await _alarmRepository.AddAlarmActivation(aa);
                                // send ws message
                                SendAlarmMessage(new AlarmActivationDTO(
                                    alarm.threshHold, alarm.Message, alarm.priority, alarm.Type, alarm.MeasureUnit, DateTime.Now));


                            }
                        }
                        else
                        {
                            if (newValue < alarm.threshHold)
                            {
                                // new alarm activation, insert to db
                                AlarmActivation aa = new AlarmActivation(alarm);
                                await _alarmRepository.AddAlarmActivation(aa);
                                // send ws message
                                SendAlarmMessage(new AlarmActivationDTO(
                                    alarm.threshHold, alarm.Message, alarm.priority, alarm.Type, alarm.MeasureUnit, DateTime.Now ));
                            }
                        }
                    }
                    // scan on of for trending
                    if (tag.OnOffScan == true)
                        {
                            SendInputChangeMessage(tag);
                        }
                    }

                

            }).Start();
        }
        private void RunDigitalThread(DigitalInput tag)
        {
            new Thread( async () =>
            {

                Console.WriteLine(tag.id);
                Thread.CurrentThread.IsBackground = true;

                while (true)
                {
                    float currValue = tag.currentValue;
                    float newValue = SimulationDriver.ReturnValue(tag.IOAddress);

                    if (newValue > 1) newValue = 1;
                    else if (newValue < 0) newValue = 0;

                    // value setting
                    Thread.Sleep((int)(tag.ScanTime * 1000));

                    if (currValue == newValue) continue;

                    PastTagValues pt = new PastTagValues(tag, currValue, tag.IOAddress);
                    tag.currentValue = newValue;

                    
                        await _tagRepository.CreatePastTagValue(pt);
                        await _tagRepository.UpdateDigitalInput(tag);

                    
                    // scan on of for trending
                    if (tag.OnOffScan)
                    {
                        SendInputChangeMessage(tag);
                    }


                }

            }).Start();
        }
        private  void SendInputChangeMessage(Tag tag)
        {
            _inputTagsHub.Clients.All.ReceiveMessage(JsonSerializer.Serialize(tag));

        }
        private  void SendAlarmMessage(AlarmActivationDTO alarm)
        {

            _alarmsHub.Clients.All.ReceiveMessage(JsonSerializer.Serialize(alarm));

        }
    }
}
