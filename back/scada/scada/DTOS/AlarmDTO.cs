using scada.Models;

namespace scada.DTOS
{
    public class AlarmDTO
    {
        public string type { get; set; }
        public DateTime timeOfActivation { get; set; }
        public int priority { get; set; }
        public string tagname { get; set; }

        public AlarmDTO(string type, DateTime timeOfActivation, int priority, string tagname)
        {
            this.type = type;
            this.timeOfActivation = timeOfActivation;
            this.priority = priority;
            this.tagname = tagname;
        }
        public AlarmDTO(Alarm alarm)
        {
            this.type = alarm.Type;
            this.timeOfActivation = alarm.timeStamp;
            this.priority = alarm.priority;
            this.tagname = alarm.tagId;

        }
    }
}
