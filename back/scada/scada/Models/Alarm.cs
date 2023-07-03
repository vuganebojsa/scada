namespace scada.Models
{
    public class Alarm
    {
        public string Id { get; set; } 
        public bool ActivateAbove { get; set; }
        public int threshHold { get; set; }
        public string Message { get; set; }
        public string tagId { get; set; }
        public DateTime timeStamp { get; set; }
        public int priority { get; set; }
        public string Type { get; set; }

        public Alarm()
        {
            
        }

        public Alarm(bool activateAbove, int threshHold, string message, string tagId, int priority, string type)
        {
            this.ActivateAbove = activateAbove;
            this.threshHold = threshHold;
            this.Message = message;
            this.timeStamp = DateTime.Now;
            this.tagId = tagId;
            this.priority = priority;
            Type = type;    
        }
    }
}
