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
            foreach (var item in _context.AnalogInputs.OrderBy(x => x.id).ToList())
            {
                tags.Add(item);
            }
            foreach (var item in _context.AnalogOutputs.OrderBy(x => x.id).ToList())
            {
                tags.Add(item);
            }
            foreach (var item in _context.DigitalInputs.OrderBy(x => x.id).ToList())
            {
                tags.Add(item);
            }
            foreach (var item in _context.DigitalOutputs.OrderBy(x => x.id).ToList())
            {
                tags.Add(item);
            }
            return tags;

        }
        public AnalogInput GetAnalogInputById(int id)
        {
            return _context.AnalogInputs.Where(x => x.id == id).FirstOrDefault();
        }
        public DigitalInput GetDigitalInputById(int id)
        {
            return _context.DigitalInputs.Where(x => x.id == id).FirstOrDefault();
        }
        public AnalogOutput GetAnalogOutputById(int id)
        {
            return _context.AnalogOutputs.Where(x => x.id == id).FirstOrDefault();
        }
        public DigitalOutput GetDigitalOutputById(int id)
        {
            return _context.DigitalOutputs.Where(x => x.id == id).FirstOrDefault();
        }

        public ICollection<AnalogInput> GetAnalogInputTags() {

            return _context.AnalogInputs.OrderBy(x => x.id).ToList();
        }

        public ICollection<DigitalInput> GetDigitalInputTags()
        {

            return _context.DigitalInputs.OrderBy(x => x.id).ToList();
        }

        public ICollection<Tag> GetOutTags()
        {

            var analogo = _context.AnalogOutputs.ToList();
            var digitalo = _context.DigitalOutputs.ToList();
            var tags = new List<Tag>();
            tags.AddRange(analogo);
            tags.AddRange(digitalo);
            return tags;
        }
    }


}

