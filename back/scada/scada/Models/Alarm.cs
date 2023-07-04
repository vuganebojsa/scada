namespace scada.Models
{
    public class Alarm
    {
        public string Id { get; set; } 

        public int threshHold { get; set; }
        public string Message { get; set; }
        public AnalogInput analogInput { get; set; }

        public int? analogId { get; set; }

        public DateTime timeStamp { get; set; }
        public int priority { get; set; }
        public string Type { get; set; }

        public Alarm()
        {
            
        }

        public Alarm(int threshHold, string message, AnalogInput analogInput, int priority, string type)
        {
            this.analogId = analogInput.id;
            this.threshHold = threshHold;
            this.Message = message;
            this.timeStamp = DateTime.Now;
            this.analogInput = analogInput;
            this.priority = priority;
            Type = type;    
        }
    }
}
