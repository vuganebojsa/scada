namespace scada.DTOS
{
    public class PastTagValuesDTO
    {
        public float Value { get; set; }
        public DateTime Timestamp { get; set; }
        public string? TagName { get; set; }
        

        public PastTagValuesDTO(float value, DateTime timestamp)
        {
            Value = value;
            Timestamp = timestamp;
        }
        public PastTagValuesDTO(float value, DateTime timestamp, string tagName)
        {
            Value = value;
            Timestamp = timestamp;
            TagName = tagName;
        }
    }
}
