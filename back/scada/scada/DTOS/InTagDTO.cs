namespace scada.DTOS
{
    public class InTagDTO
    {
        public int? Id { get; set; }
        public string TagName { get; set; }
        public float CurrentValue { get; set; }
        public bool IsScanOn { get; set; }
        public string? Type { get;set }

        public InTagDTO(int? id, string tagName, float currentValue, bool isScanOn, string type)
        {
            Id = id;
            TagName = tagName;
            IsScanOn = isScanOn;
            CurrentValue = currentValue;
            Type = type;
        }
    }
}
