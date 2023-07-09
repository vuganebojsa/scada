namespace scada.DTOS
{
    public class AnalogOutputDTO
    {
        public float currentValue { get; set; } 
        public string tagName { get; set; }
        public string Description { get; set; }
        public string IOAddress { get; set; }
        public float InitialValue { get; set; }
        public double LowLimit { get; set; }
        public double HighLimit { get; set; }
        public string Units { get; set; }
        public AnalogOutputDTO(float currentValue, string tagName, string description, string iOAddress, float initialValue, double lowLimit, double highLimit, string units)
        {
            this.currentValue = currentValue;
            this.tagName = tagName;
            Description = description;
            IOAddress = iOAddress;
            InitialValue = initialValue;
            LowLimit = lowLimit;
            HighLimit = highLimit;
            Units = units;
        }
    }
}
