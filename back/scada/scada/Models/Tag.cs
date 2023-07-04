namespace scada.Models
{
    public class Tag
    {
        public int? id { get; set; }

        public string tagName { get; set; }

        public string description { get; set; }

        public float currentValue { get; set; }


        public Tag()
        {
            
        }

        public Tag( string tagName, string description, float currentValue)
        {

            this.tagName = tagName;
            this.description = description;
            this.currentValue = currentValue;

        }
    }
}
