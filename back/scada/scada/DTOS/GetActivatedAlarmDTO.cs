namespace scada.DTOS
{
    public class GetActivatedAlarmDTO
    {
        public int Priority { get; set; }
        public string Type { get; set; }
        public DateTime timeStamp { get; set; }
        public string MeasureUnit { get; set; }
        public GetActivatedAlarmDTO(int priority, string type, DateTime timeStamp, string measureUnit)
        {
            Priority = priority;
            Type = type;
            this.timeStamp = timeStamp;
            MeasureUnit = measureUnit;
        }
    }
}
