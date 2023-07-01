using scada.DTOS;

namespace scada.Models
{
    public class AnalogOutput : Tag
    {

        public string? Id { get; set; }
        public string Description { get; set; }
        public string IOAddress { get; set; }
        public int InitialValue { get; set; }
        public double LowLimit { get; set; }
        public double HighLimit { get; set; }
        public string Units { get; set; }
           
        public AnalogOutput()
        {

        }
        public AnalogOutput(string? id, string description, string iOAddress, int initialValue, double lowLimit, double highLimit, string units)
        {
            Id = id;
            Description = description;
            IOAddress = iOAddress;
            InitialValue = initialValue;
            LowLimit = lowLimit;
            HighLimit = highLimit;
            Units = units;
        }

        public AnalogOutput(AnalogOutputDTO analogOutputDTO)
        {
            Description = analogOutputDTO.Description;
            IOAddress = analogOutputDTO.IOAddress;
            InitialValue = analogOutputDTO.InitialValue;
            LowLimit = analogOutputDTO.LowLimit;
            HighLimit = analogOutputDTO.HighLimit;
            Units = analogOutputDTO.Units;

        }
    }
}
