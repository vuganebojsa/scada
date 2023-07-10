namespace scada.DTOS
{
    public class OutTagsValueDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Value { get; set; }
        public OutTagsValueDTO(int id, string type, int value)
        {
            Id = id;
            Type = type;
            Value = value;
        }
    }
}