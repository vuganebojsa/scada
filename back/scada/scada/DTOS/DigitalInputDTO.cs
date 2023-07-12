namespace scada.DTOS
{
    public class DigitalInputDTO
    {
        public string tagName { get; set; }
        public float initialValue { get; set; }
        public string Description { get; set; }
        public float ScanTime { get; set; }
        public DigitalInputDTO()
        {
        }

        public DigitalInputDTO(string tagName,float initialValue, string description,float scanTime)
        {
            this.tagName = tagName;
            this.initialValue = initialValue;
            Description = description;
            ScanTime = scanTime;
        }

    }
}
