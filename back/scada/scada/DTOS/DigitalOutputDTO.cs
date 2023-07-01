namespace scada.DTOS
{
    public class DigitalOutputDTO
    {
        public string Description { get; set; }
        public string IOAddress { get; set; }
        public int InitialValue { get; set; }

        public DigitalOutputDTO(string description, string iOAddress, int initialValue)
        {
            Description = description;
            IOAddress = iOAddress;
            InitialValue = initialValue;
        }
    }
}
