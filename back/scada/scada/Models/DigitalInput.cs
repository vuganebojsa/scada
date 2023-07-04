using scada.DTOS;

namespace scada.Models
{
    public class DigitalInput : Tag
    {

        public string IOAddress { get; set; }
        public int ScanTime { get; set; }
        public bool OnOffScan { get; set; }
        public string Driver { get; set; }
        public DigitalInput()
        {
        }

        public DigitalInput(float currentValue, string tagName, string description, string iOAddress, int scanTime, bool onOffScan, string driver):base(tagName, description, currentValue)
        {

            IOAddress = iOAddress;
            ScanTime = scanTime;
            OnOffScan = onOffScan;
            Driver = driver;
        }
        public DigitalInput(DigitalInputDTO digitalInputDTO)
        {
            base.description = digitalInputDTO.Description;
            base.currentValue = digitalInputDTO.currentValue;
            base.tagName = digitalInputDTO.tagName;
            IOAddress = digitalInputDTO.IOAddress;
            ScanTime = digitalInputDTO.ScanTime;
            Driver = digitalInputDTO.Driver;
            OnOffScan = true;
        }
       
    }
}
