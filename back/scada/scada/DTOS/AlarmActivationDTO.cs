namespace scada.DTOS
{
    public class AlarmActivationDTO
    {
        public float Threshold { get; set; }
        public string Message { get; set; }
        public int Priority { get; set; }
        public string Type { get; set; }
        public string MeasureUnit { get; set; }
        public DateTime Timestamp { get; set; }

        public AlarmActivationDTO(float threshold, string message, int priority, string type, string measureUnit, DateTime timestamp)
        {
            Threshold = threshold;
            Message = message;
            Priority = priority;
            Type = type;
            MeasureUnit = measureUnit;
            Timestamp = timestamp;
        }
    }
}
