using scada.DTOS;

namespace scada.Models
{
    public class DigitalOutput : Tag
    {

        public string IOAddress { get; set; }

        public int InitialValue { get; set; }

        public DigitalOutput()
        {
        }

        public DigitalOutput(string tagName, string description, float currentValue, string iOAddress, int initialValue):base(tagName, description, currentValue)
        {

            IOAddress = iOAddress;
            InitialValue = initialValue;
        }
        public DigitalOutput(DigitalOutputDTO digitalOutputDTO)
        {
            base.description = digitalOutputDTO.Description;
            base.currentValue = digitalOutputDTO.currentValue;
            base.tagName = digitalOutputDTO.tagName;
            IOAddress = digitalOutputDTO.IOAddress;
            InitialValue = digitalOutputDTO.InitialValue;
        }

    }
}
