using scada.DTOS;
using scada.Models;

namespace scada.Interfaces
{
    public interface ITagRepository
    {
        ICollection<Tag> GetTags();
        ICollection<Tag> GetOutTags();
        bool DeleteOutTag(int id, string type);
        ICollection<Tag> GetInTags();
        bool SetScan(int id, string type, bool isOn);
        DigitalOutputDTO CreateDigitalOutputTag(DigitalOutputDTO digitalTagDto);
        DigitalInputDTO CreateDigitalInputTag(DigitalInputDTO digitalTagDto);
    }
}
