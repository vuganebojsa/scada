using scada.DTOS;

namespace scada.Models
{
    public class AnalogOutput : Tag
    {


        public string IOAddress { get; set; }
        public float InitialValue { get; set; }
        public double LowLimit { get; set; }
        public double HighLimit { get; set; }
        public string Units { get; set; }
           
        public AnalogOutput()
        {
            base.isDeleted = false;
        }
        public AnalogOutput(float currentValue, string tagName, string description, string iOAddress, float initialValue, double lowLimit, double highLimit, string units):base(tagName, description, currentValue)
        {

            InitialValue = initialValue;
            LowLimit = lowLimit;
            HighLimit = highLimit;
            Units = units;

            IOAddress = base.GetIOAddress();
            base.isDeleted = false;
        }

        public AnalogOutput(AnalogOutputDTO analogOutputDTO)
        {
            base.currentValue = analogOutputDTO.currentValue;
            base.description = analogOutputDTO.Description;
            base.tagName = analogOutputDTO.tagName;
            InitialValue = analogOutputDTO.InitialValue;
            LowLimit = analogOutputDTO.LowLimit;
            HighLimit = analogOutputDTO.HighLimit;
            Units = analogOutputDTO.Units;

            IOAddress = base.GetIOAddress();
            base.isDeleted = false;

        }
    }
}
