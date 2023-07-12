using scada.Models;

namespace scada.DTOS
{
    public class AlarmReportDTO
    {
        public string type { get; set; }
        public DateTime timeOfActivation { get; set; }
        public int priority { get; set; }
        public string tagName { get; set; }

        public AlarmReportDTO(Alarm alarm)
        {
            this.type = alarm.Type;
            this.timeOfActivation = alarm.timeStamp;
            this.priority = alarm.priority;
            this.tagName = alarm.analogInput.tagName;
        }
    }
}
