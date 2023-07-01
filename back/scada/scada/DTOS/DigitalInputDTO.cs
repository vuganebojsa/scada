namespace scada.DTOS
{
    public class DigitalInputDTO
    {
        public string Description { get; set; }
        public string IOAddress { get; set; }
        public int ScanTime { get; set; }
        public string Driver { get; set; }
        public DigitalInputDTO()
        {
        }

        public DigitalInputDTO(string description, string iOAddress, int scanTime, string driver)
        {
            Description = description;
            IOAddress = iOAddress;
            ScanTime = scanTime;
            Driver = driver;
        }

    }
}
