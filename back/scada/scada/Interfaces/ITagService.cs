using scada.DTOS;

namespace scada.Interfaces
{
    public interface ITagService
    {

        ICollection<OutTagDTO> GetOutTags();
        bool DeleteOutTag(int id, string type);
    }
}
