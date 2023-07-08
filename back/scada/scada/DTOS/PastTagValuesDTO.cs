namespace scada.DTOS
{
    public class PastTagValuesDTO
    {
        public float Value { get; set; }
        public DateTime Timestamp { get; set; }

        public PastTagValuesDTO(float value, DateTime timestamp)
        {
            Value = value;
            Timestamp = timestamp;
        }
    }
}
