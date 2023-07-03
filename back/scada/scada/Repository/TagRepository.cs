using scada.Data;
using scada.Interfaces;
using scada.Models;

namespace scada.Repository {
    public class TagRepository : ITagRepository
    {
        private readonly DataContext _context;
        public TagRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Tag> GetTags()
        {
            ICollection<Tag> tags = new HashSet<Tag>();
            foreach (var item in _context.AnalogInputs.OrderBy(x => x.Id).ToList())
            {
                tags.Add(item);
            }
            foreach (var item in _context.AnalogOutputs.OrderBy(x => x.Id).ToList())
            {
                tags.Add(item);
            }
            foreach (var item in _context.DigitalInputs.OrderBy(x => x.Id).ToList())
            {
                tags.Add(item);
            }
            foreach (var item in _context.DigitalOutputs.OrderBy(x => x.Id).ToList())
            {
                tags.Add(item);
            }
            return tags;

        }
        public AnalogInput GetAnalogInputById(string id)
        {
            return _context.AnalogInputs.Where(x => x.Id == id).FirstOrDefault();
        }
        public DigitalInput GetDigitalInputById(string id)
        {
            return _context.DigitalInputs.Where(x => x.Id == id).FirstOrDefault();
        }
        public AnalogOutput GetAnalogOutputById(string id)
        {
            return _context.AnalogOutputs.Where(x => x.Id == id).FirstOrDefault();
        }
        public DigitalOutput GetDigitalOutputById(string id)
        {
            return _context.DigitalOutputs.Where(x => x.Id == id).FirstOrDefault();
        }

        public ICollection<AnalogInput> GetAnalogInputTags() {

            return _context.AnalogInputs.OrderBy(x => x.Id).ToList();
        }

        public ICollection<DigitalInput> GetDigitalInputTags()
        {

            return _context.DigitalInputs.OrderBy(x => x.Id).ToList();
        }


    }


}

