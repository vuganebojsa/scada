namespace scada.Models
{
    public class Tag
    {
        public int? id { get; set; }

        public string tagName { get; set; }

        public string? description { get; set; }

        public float currentValue { get; set; }

        public bool isDeleted { get; set; }

        public Tag()
        {
            isDeleted = false;
        }

        public Tag( string tagName, string description, float currentValue)
        {

            this.tagName = tagName;
            this.description = description;
            this.currentValue = currentValue;
            isDeleted = false;

        }

        public string GetIOAddress()
        {
            Random random = new Random();
            string[] values = { "S", "C", "R" };
            string randomValue = values[random.Next(values.Length)];
            return randomValue;
        }
    }
}
