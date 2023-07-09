namespace scada.DTOS
{
    public class AnalogInputDTO
    {
        public float currentValue { get; set; }
        public string tagName { get; set; }
        public string Description { get; set; }
        public string Driver { get; set; }
        public string IOAddress { get; set; }
        public float ScanTime { get; set; }
        public double LowLimit { get; set; }
        public double HighLimit { get; set; }
        public string Units { get; set; }

        public AnalogInputDTO(float currentValue, string tagName,string description, string driver, string iOAddress, float scanTime, double lowLimit, double highLimit, string units)
        {
            this.currentValue = currentValue;
            this.tagName = tagName;
            Description = description;
            Driver = driver;
            IOAddress = iOAddress;
            ScanTime = scanTime;
            LowLimit = lowLimit;
            HighLimit = highLimit;
            Units = units;
        }
    }
}
