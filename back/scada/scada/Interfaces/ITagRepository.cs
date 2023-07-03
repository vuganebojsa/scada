using scada.Models;

namespace scada.Interfaces
{
    public interface ITagRepository
    {
        ICollection<Tag> GetTags();

    }
}
