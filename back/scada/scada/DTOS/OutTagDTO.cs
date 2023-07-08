﻿namespace scada.DTOS
{
    public class OutTagDTO
    {
        public int? Id { get; set; }
        public string TagName { get; set; }
        public float CurrentValue { get; set; }
        public string Type { get; set; }
        public OutTagDTO(int? id, string tagName, float currentValue, string type)
        {
            Id = id;
            TagName = tagName;
            CurrentValue = currentValue;
            Type = type;
        }
    }
}
