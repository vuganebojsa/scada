namespace scada.DTOS
{
    public class AnalogInputDTO
    {
        public string Description { get; set; }
        public string Driver { get; set; }
        public string IOAddress { get; set; }
        public int ScanTime { get; set; }
        public double LowLimit { get; set; }
        public double HighLimit { get; set; }
        public string Units { get; set; }

        public AnalogInputDTO(string description, string driver, string iOAddress, int scanTime, double lowLimit, double highLimit, string units)
        {
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
