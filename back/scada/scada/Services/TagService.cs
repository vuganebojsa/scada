using scada.DTOS;
using scada.Interfaces;

namespace scada.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public ICollection<OutTagDTO> GetOutTags()
        {
            throw new NotImplementedException();
        }
    }
}
