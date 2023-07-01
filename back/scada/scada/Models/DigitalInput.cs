using scada.DTOS;

namespace scada.Models
{
    public class DigitalInput : Tag
    {
        public string? Id { get; set; }
        public string Description { get; set; }
        public string IOAddress { get; set; }
        public int ScanTime { get; set; }
        public bool OnOffScan { get; set; }
        public string Driver { get; set; }
        public DigitalInput()
        {
        }

        public DigitalInput(string id, string description, string iOAddress, int scanTime, bool onOffScan, string driver)
        {
            Id = id;
            Description = description;
            IOAddress = iOAddress;
            ScanTime = scanTime;
            OnOffScan = onOffScan;
            Driver = driver;
        }
        public DigitalInput(DigitalInputDTO digitalInputDTO)
        {
            
            Description = digitalInputDTO.Description;
            IOAddress = digitalInputDTO.IOAddress;
            ScanTime = digitalInputDTO.ScanTime;
            Driver = digitalInputDTO.Driver;
            OnOffScan = true;
        }
       
    }
}
