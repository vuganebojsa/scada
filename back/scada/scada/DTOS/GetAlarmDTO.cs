namespace scada.DTOS
{
    public class GetAlarmDTO
    {

        public int? AnalogId { get; set; }
        public int Threshold { get; set; }
        public string Message { get; set; }
        public int Priority { get; set; }
        public string Type { get; set; }
        public DateTime timeStamp { get; set; }
        public string MeasureUnit { get; set; }
        public GetAlarmDTO(int? analogId, int threshold, string message, int priority, string type, DateTime timeOfCreation, string measureUnit)
        {
            AnalogId = analogId;
            Threshold = threshold;
            Message = message;
            Priority = priority;
            Type = type;
            timeStamp = timeOfCreation;
            MeasureUnit = measureUnit;
        }
    }
}
