namespace scada.DTOS
{
    public class InTagsScanDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public bool IsOn { get; set; }
        public InTagsScanDTO(int id, string type, bool isOn)
        {
            Id = id;
            Type = type;
            IsOn = isOn;
        }
    }
}
