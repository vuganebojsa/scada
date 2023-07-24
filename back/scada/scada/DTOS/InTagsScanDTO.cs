using scada.ErrorHandlers;

namespace scada.DTOS
{
    public class InTagsScanDTO
    {
        [CustomRequired("Id")]
        public int Id { get; set; }
        [CustomRequired("Type")]
        public string Type { get; set; }

        [CustomRequired("Is Tag On")]
        public bool IsOn { get; set; }
        public InTagsScanDTO(int id, string type, bool isOn)
        {
            Id = id;
            Type = type;
            IsOn = isOn;
        }
    }
}
