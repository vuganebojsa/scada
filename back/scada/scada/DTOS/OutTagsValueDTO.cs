using scada.ErrorHandlers;

namespace scada.DTOS
{
    public class OutTagsValueDTO
    {
        [CustomRequired("Id")]
        public int Id { get; set; }

        [CustomRequired("Id")]

        public string Type { get; set; }
        [CustomRequired("Id")]

        public int Value { get; set; }
        public OutTagsValueDTO(int id, string type, int value)
        {
            Id = id;
            Type = type;
            Value = value;
        }
    }
}