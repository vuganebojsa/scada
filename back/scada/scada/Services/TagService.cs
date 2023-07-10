using scada.DTOS;
using scada.Interfaces;
using scada.Models;

namespace scada.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IAlarmRepository _alarmRepository;


        public TagService(ITagRepository tagRepository, IAlarmRepository alarmRepository)
        {
            _tagRepository = tagRepository;
            _alarmRepository = alarmRepository;
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
            foreach(var tag in digitalInputs)
            {

                RunDigitalThread(tag);
            }
        }

        private void RunAnalogThread(AnalogInput tag)
        {
            new Thread(async () =>
            {
                Thread.CurrentThread.IsBackground = true;

                while (true)
                {
                    float currValue = tag.currentValue;
                    float newValue = SimulationDriver.ReturnValue(tag.IOAddress);

                    if (newValue > tag.HighLimit) newValue = (float)tag.HighLimit;
                    else if (newValue < tag.LowLimit) newValue = (float)tag.LowLimit;

                    // value setting
                    Thread.Sleep((int)(tag.ScanTime * 1000));
                    PastTagValues pt = new PastTagValues(tag, currValue, tag.IOAddress);
                    tag.currentValue = newValue;
                    _tagRepository.CreatePastTagValue(pt);
                    _tagRepository.UpdateAnalogInput(tag);

                    // alarms
                    var alarms = this._alarmRepository.GetAllAlarmsById(tag.id);

                    foreach(var alarm in alarms)
                    {
                        if(alarm.Type.ToLower() == "high")
                        {
                            if(newValue > alarm.threshHold)
                            {
                                // new alarm activation, insert to db
                                // send ws message

                            }
                        }
                        else
                        {
                            if(newValue < alarm.threshHold)
                            {
                                // new alarm activation, insert to db
                                // send ws message
                            }
                        }
                    }

                    // scan on of for trending
                    if (tag.OnOffScan)
                    {
                        SendAnalogInputChangeMessage();
                    }


                }

            }).Start();
        }
        private void RunDigitalThread(DigitalInput tag)
        {

        }
        private void SendAnalogInputChangeMessage()
        {

        }
    }
}
