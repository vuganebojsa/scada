﻿namespace scada.Models
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

        public string? MeasureUnit { get; set; }
        public bool isDeleted { get; set; }
        public Alarm()
        {
            
        }

        public Alarm(int threshHold, string message, AnalogInput analogInput, int priority, string type)
        {
            this.threshHold = threshHold;
            this.Message = message;
            this.timeStamp = DateTime.Now;
            this.analogInput = analogInput;
            this.analogId = analogInput.id;
            this.priority = priority;
            Type = type;
            isDeleted = false;
        }
        public Alarm(int threshHold, string message, AnalogInput analogInput, int priority, string type, string measureUnit)
        {
            this.threshHold = threshHold;
            this.Message = message;
            this.timeStamp = DateTime.Now;
            this.analogInput = analogInput;
            this.analogId = analogInput.id;
            this.priority = priority;
            Type = type;
            MeasureUnit = measureUnit;

            isDeleted = false;
        }
        public Alarm(int threshHold, string message,  int priority, string type)
        {
            //this.analogId = analogInput.id;
            this.threshHold = threshHold;
            this.Message = message;
            this.timeStamp = DateTime.Now;
            this.priority = priority;
            Type = type;

            isDeleted = false;
        }
    }
}
