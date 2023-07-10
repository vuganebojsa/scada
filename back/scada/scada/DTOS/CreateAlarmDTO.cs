namespace scada.DTOS
{
    public class CreateAlarmDTO
    {

        public int AnalogId { get; set; }
        public int Threshold { get; set; }
        public string Message { get; set; }
        public int Priority { get; set; }
        public string Type { get; set; }

        public CreateAlarmDTO(int analogId, int threshold, string message, int priority, string type)
        {
            AnalogId = analogId;
            Threshold = threshold;
            Message = message;
            Priority = priority;
            Type = type;
        }
    }
}
