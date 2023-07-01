using scada.DTOS;

namespace scada.Models
{
    public class DigitalOutput : Tag
    {
        public string? Id { get; set; }
        public string Description { get; set; }
        public string IOAddress { get; set; }

        public int InitialValue { get; set; }
        public DigitalOutput()
        {
        }

        public DigitalOutput(string id, string description, string iOAddress, int initialValue)
        {
            Id = id;
            Description = description;
            IOAddress = iOAddress;
            InitialValue = initialValue;
        }
        public DigitalOutput(DigitalOutputDTO digitalOutputDTO)
        {
            Description = digitalOutputDTO.Description;
            IOAddress = digitalOutputDTO.IOAddress;
            InitialValue = digitalOutputDTO.InitialValue;
        }

    }
}
