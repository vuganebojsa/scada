namespace scada.DTOS
{
    public class OutTagDTO
    {
        public int? Id { get; set; }
        public string TagName { get; set; }
        public float CurrentValue { get; set; }
        public OutTagDTO(int id, string tagName, float currentValue)
        {
            Id = id;
            TagName = tagName;
            CurrentValue = currentValue;
        }
    }
}
