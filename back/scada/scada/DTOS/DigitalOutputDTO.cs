namespace scada.DTOS
{
    public class DigitalOutputDTO
    {
        public string tagName { get; set; }

        public string Description { get; set; }
        public int InitialValue { get; set; }

        public DigitalOutputDTO(string tagName, string description,  int initialValue)
        {   
      
            this.tagName = tagName;
            Description = description;
            InitialValue = initialValue;
        }
    }
}
