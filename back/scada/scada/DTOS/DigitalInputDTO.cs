namespace scada.DTOS
{
    public class DigitalInputDTO
    {
        public string tagName { get; set; }
        public float currentValue { get; set; }
        public string Description { get; set; }
        public string IOAddress { get; set; }
        public int ScanTime { get; set; }
        public string Driver { get; set; }
        public DigitalInputDTO()
        {
        }

        public DigitalInputDTO(string tagName,float currentValue, string description, string iOAddress, int scanTime, string driver)
        {
            this.tagName = tagName;
            this.currentValue = currentValue;
            Description = description;
            IOAddress = iOAddress;
            ScanTime = scanTime;
            Driver = driver;
        }

    }
}
