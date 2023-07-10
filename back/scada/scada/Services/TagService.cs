using Microsoft.AspNetCore.SignalR;
using scada.Data;
using scada.DTOS;
using scada.Hubs;
using scada.Interfaces;
using scada.Models;

namespace scada.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IAlarmRepository _alarmRepository;
        private readonly IHubContext<AlarmsHub, IAlarmHubClient> _alarmsHub;
        private readonly IHubContext<InputTagsHub, IINputTagHubClient> _inputTagsHub;
        private object _lock = new object();


        public TagService(ITagRepository tagRepository, 
            IAlarmRepository alarmRepository,
            IHubContext<InputTagsHub, IINputTagHubClient> inputTagsHub, IHubContext<AlarmsHub, IAlarmHubClient> alarmsHub)
        {
            _tagRepository = tagRepository;
            _alarmRepository = alarmRepository;
            _inputTagsHub = inputTagsHub;
            _alarmsHub = alarmsHub;
        }

        public DigitalInputDTO CreateDigitalInputTag(DigitalInputDTO digitalTagDto)
        {
            return this._tagRepository.CreateDigitalInputTag(digitalTagDto);
        }

        public DigitalOutputDTO CreateDigitalOutputTag(DigitalOutputDTO digitalTagDto)
        {

            return this._tagRepository.CreateDigitalOutputTag(digitalTagDto);
        }

        public bool DeleteOutTag(int id, string type)
        {
            return this._tagRepository.DeleteOutTag(id, type);
        }

        public ICollection<InTagDTO> GetInTags()
        {
            var tags = _tagRepository.GetInTags();

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

        public ICollection<OutTagDTO> GetOutTags()
        {
            var tags = this._tagRepository.GetOutTags();

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


        public AnalogOutputDTO CreateOutputTag(AnalogOutputDTO analogOutputDTO)
        {
            return this._tagRepository.CreateAnalogOutput(analogOutputDTO);
        }

        public bool SetScan(int id, string type, bool isOn)
        {
            return this._tagRepository.SetScan(id, type, isOn);
        }

        public bool SetValue(int id, string type, int value)
        {
            return this._tagRepository.SetValue(id, type, value);
        }

        public AnalogInput createAnalogInput(AnalogInputDTO analogTagDto)
        {
            
            return this._tagRepository.createAnalogInput(analogTagDto);

        }

        public bool DeleteInTag(int id, string type)
        {
            return this._tagRepository.DeleteInTag(id, type);
        }

        public void StartSimulation()
        {
            var analogInputs = this._tagRepository.GetAnalogInputTags();
            var digitalInputs = this._tagRepository.GetDigitalInputTags();

            foreach(var tag in analogInputs)
            {
                RunAnalogThread(tag);
            }
            //foreach(var tag in digitalInputs)
            //{

            //    RunDigitalThread(tag);
            //}
        }

        private void RunAnalogThread(AnalogInput tag)
        {
            new Thread( () =>
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

                    lock (_lock) // Acquire the lock before accessing shared resources
                    {
                        tag.currentValue = newValue;

                        _tagRepository.CreatePastTagValue(pt);
                        _tagRepository.UpdateAnalogInput(tag);


                        // alarms

                        var alarms = this._alarmRepository.GetAllAlarmsById(tag.id);

                        foreach (var alarm in alarms)
                        {
                            if (alarm.Type.ToLower() == "high")
                            {
                                if (newValue > alarm.threshHold)
                                {
                                    // new alarm activation, insert to db
                                    AlarmActivation aa = new AlarmActivation(alarm);
                                    _alarmRepository.AddAlarmActivation(aa);
                                    // send ws message
                                    SendAlarmMessage(alarm);


                                }
                            }
                            else
                            {
                                if (newValue < alarm.threshHold)
                                {
                                    // new alarm activation, insert to db
                                    AlarmActivation aa = new AlarmActivation(alarm);
                                    _alarmRepository.AddAlarmActivation(aa);
                                    // send ws message
                                    SendAlarmMessage(alarm);
                                }
                            }
                        }
                        // scan on of for trending
                        if (tag.OnOffScan == true)
                        {
                            SendInputChangeMessage();
                        }
                    }

                }

            }).Start();
        }
        private void RunDigitalThread(DigitalInput tag)
        {
            new Thread(async () =>
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

                    
                        _tagRepository.CreatePastTagValue(pt);
                        _tagRepository.UpdateDigitalInput(tag);

                    
                    // scan on of for trending
                    if (tag.OnOffScan)
                    {
                        SendInputChangeMessage();
                    }


                }

            }).Start();
        }
        private void SendInputChangeMessage()
        {
            _inputTagsHub.Clients.All.ReceiveMessage("");

        }
        private void SendAlarmMessage(Alarm alarm)
        {
            _alarmsHub.Clients.All.ReceiveMessage("");

        }
    }
}
