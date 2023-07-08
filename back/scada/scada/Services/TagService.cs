using scada.DTOS;
using scada.Interfaces;
using scada.Models;

namespace scada.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public bool DeleteOutTag(int id, string type)
        {
            return this._tagRepository.DeleteOutTag(id, type);
        }

        public ICollection<OutTagDTO> GetOutTags()
        {
            var tags = this._tagRepository.GetOutTags();

            var newTags = new List<OutTagDTO>();
            foreach(Tag tag in tags)
            {
                if (tag is AnalogOutput)
                    newTags.Add(new OutTagDTO(tag.id, tag.tagName, tag.currentValue, "AnalogOutput"));
                else
                    newTags.Add(new OutTagDTO(tag.id, tag.tagName, tag.currentValue, "DigitalOutput"));

            }

            return newTags;
        }
    }
}
