using scada.DTOS;

namespace scada.Models
{
    public class PastTagValues
    {
        public string? Id { get; set; }
        public Tag tag { get; set; }

        public int? tagId { get; set; }

        public DateTime timeStamp { get; set; }

        public float value { get; set; }

        public string address { get; set; }


        public PastTagValues() { }

        public PastTagValues(Tag tag1, float value, string address)
        {
            this.tagId = tag1.id;
            this.tag = tag1;
            this.timeStamp = DateTime.Now;
            this.value = value;
            this.address = address;
        }
    }
}
