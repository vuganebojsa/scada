using scada.DTOS;

namespace scada.Models
{
    public class DigitalInput : Tag
    {

        public string IOAddress { get; set; }
        public float ScanTime { get; set; }
        public bool OnOffScan { get; set; }
        public string Driver { get; set; }
        public DigitalInput()
        {
            base.isDeleted = false;
        }

        public DigitalInput(float currentValue, string tagName, string description, string iOAddress, float scanTime, bool onOffScan, string driver):base(tagName, description, currentValue)
        {

            ScanTime = scanTime;
            OnOffScan = onOffScan;
            Driver = driver;

            IOAddress = base.GetIOAddress();
            base.isDeleted = false;
        }
        public DigitalInput(DigitalInputDTO digitalInputDTO)
        {
            base.description = digitalInputDTO.Description;
            base.currentValue = digitalInputDTO.initialValue;
            base.tagName = digitalInputDTO.tagName;
            ScanTime = digitalInputDTO.ScanTime;
            Driver = "";

            IOAddress = base.GetIOAddress();
            OnOffScan = true;
            base.isDeleted = false;
        }
       
    }
}
