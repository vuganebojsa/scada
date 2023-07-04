using scada.Models;

namespace scada.DTOS
{
    public class AlarmDTO
    {
        public string type { get; set; }
        public DateTime timeOfActivation { get; set; }
        public int priority { get; set; }
        public AnalogInput analogInput { get; set; }

        public AlarmDTO(string type, DateTime timeOfActivation, int priority, AnalogInput analogInput)
        {
            this.type = type;
            this.timeOfActivation = timeOfActivation;
            this.priority = priority;
            this.analogInput = analogInput;
        }
        public AlarmDTO(Alarm alarm)
        {
            this.type = alarm.Type;
            this.timeOfActivation = alarm.timeStamp;
            this.priority = alarm.priority;
            this.analogInput = alarm.analogInput;

        }
    }
}
