using scada.ErrorHandlers;

namespace scada.DTOS
{
    public class AnalogInputDTO
    {

        [CustomRequired("Current Value")]
        public float currentValue { get; set; }

        [CustomRequired("Current Value")]
        [CustomMaxLength("Tag name", 30)]
        [CustomMinLength("Tag name", 2)]

        public string tagName { get; set; }

        [CustomRequired("Current Value")]
        [CustomMaxLength("Description", 300)]

        public string Description { get; set; }

        public string Driver { get; set; }
        public string IOAddress { get; set; }

        [CustomRequired("Current Value")]
        public float ScanTime { get; set; }

        [CustomRequired("Current Value")]
        public double LowLimit { get; set; }

        [CustomRequired("Current Value")]
        public double HighLimit { get; set; }

        [CustomRequired("Current Value")]
        [CustomMaxLength("Units", 10)]
        public string Units { get; set; }

        public AnalogInputDTO(float currentValue, string tagName,string description, float scanTime, double lowLimit, double highLimit, string units)
        {
            this.currentValue = currentValue;
            this.tagName = tagName;
            Description = description;
            Driver = "";
            IOAddress = "";
            ScanTime = scanTime;
            LowLimit = lowLimit;
            HighLimit = highLimit;
            Units = units;
        }
    }
}
