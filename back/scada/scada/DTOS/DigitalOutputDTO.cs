namespace scada.DTOS
{
    public class DigitalOutputDTO
    {
        public string tagName { get; set; }

        public float currentValue { get; set; }
        public string Description { get; set; }
        public string IOAddress { get; set; }
        public int InitialValue { get; set; }

        public DigitalOutputDTO(float currentValue, string tagName, string description, string iOAddress, int initialValue)
        {
            this.currentValue = currentValue;
            this.tagName = tagName;
            Description = description;
            IOAddress = iOAddress;
            InitialValue = initialValue;
        }
    }
}
