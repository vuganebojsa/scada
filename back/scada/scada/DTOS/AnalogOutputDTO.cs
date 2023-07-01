namespace scada.DTOS
{
    public class AnalogOutputDTO
    {
        public string Description { get; set; }
        public string IOAddress { get; set; }
        public int InitialValue { get; set; }
        public double LowLimit { get; set; }
        public double HighLimit { get; set; }
        public string Units { get; set; }
        public AnalogOutputDTO(string description, string iOAddress, int initialValue, double lowLimit, double highLimit, string units)
        {
            Description = description;
            IOAddress = iOAddress;
            InitialValue = initialValue;
            LowLimit = lowLimit;
            HighLimit = highLimit;
            Units = units;
        }
    }
}
