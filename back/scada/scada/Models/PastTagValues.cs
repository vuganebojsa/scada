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

        public PastTagValues(Tag tag, float value, string address)
        {
            this.tagId = tag.id;
            this.tag = tag;
            this.timeStamp = DateTime.Now;
            this.value = value;
            this.address = address;
        }
    }
}
