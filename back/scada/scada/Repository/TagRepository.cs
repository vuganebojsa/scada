using scada.Data;
using scada.DTOS;
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
            var newTags = new List<Tag>();
            foreach (Tag t in tags)
            {
                if (!t.isDeleted) newTags.Add(t);
            }
            return newTags;

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

            return _context.AnalogInputs.Where(x => x.isDeleted == false).OrderBy(x => x.id).ToList();
        }

        public ICollection<DigitalInput> GetDigitalInputTags()
        {

            return _context.DigitalInputs.Where(x => x.isDeleted == false).OrderBy(x => x.id).ToList();
        }

        public ICollection<Tag> GetOutTags()
        {

            var analogo = _context.AnalogOutputs.ToList();
            var digitalo = _context.DigitalOutputs.ToList();
            var tags = new List<Tag>();
            tags.AddRange(analogo);
            tags.AddRange(digitalo);
            var newTags = new List<Tag>();
            foreach (Tag t in tags)
            {
                if (!t.isDeleted) newTags.Add(t);
            }
            return newTags;
        }

        public bool DeleteOutTag(int id, string type)
        {
            if(type.ToLower() == "analogoutput")
            {
                var ano = _context.AnalogOutputs.Where(x => x.id == id).FirstOrDefault();
                if (ano == null) return false;
                ano.isDeleted = true;
            }
            else
            {
                var ano = _context.DigitalOutputs.Where(x => x.id == id).FirstOrDefault();
                if (ano == null) return false;
                ano.isDeleted = true;

                //_context.DigitalOutputs.Remove(ano);
            }
            _context.SaveChanges();
            return true;
        }

        public ICollection<Tag> GetInTags()
        {
            var analogo = _context.AnalogInputs.ToList();
            var digitalo = _context.DigitalInputs.ToList();
            var tags = new List<Tag>();

            tags.AddRange(analogo);
            tags.AddRange(digitalo);
            var newTags = new List<Tag>();
            foreach(Tag t in tags)
            {
                if (!t.isDeleted) newTags.Add(t);
            }
            return newTags;
        }

        public bool SetScan(int id, string type, bool isOn)
        {
            if(type.ToLower() == "digitalinput")
            {
                var ano = _context.DigitalInputs.Where(x => x.id == id).FirstOrDefault();
                if (ano == null) return false;
                ano.OnOffScan = isOn;
                
            }
            else
            {
                var ano = _context.AnalogInputs.Where(x => x.id == id).FirstOrDefault();
                if (ano == null) return false;
                ano.OnOffScan = isOn;
            }
            _context.SaveChanges();

            return true;
        }

        public bool SetValue(int id, string type, int newValue)
        {
            if (type.ToLower() == "digitaloutput")
            {
                var ano = _context.DigitalOutputs.Where(x => x.id == id).FirstOrDefault();
                if (ano == null) return false;
                if (newValue!=0 && newValue != 1)
                {
                    return false;
                }
                PastTagValues pastValue = new PastTagValues(ano, ano.currentValue, "");
                _context.PastTagValues.Add(pastValue);
                ano.currentValue = newValue;


            }
            else
            {
                var ano = _context.AnalogOutputs.Where(x => x.id == id).FirstOrDefault();
                if (ano == null) return false;
                if (newValue > ano.HighLimit || newValue < ano.LowLimit)
                {
                    return false;
                }
                PastTagValues pastValue = new PastTagValues(ano, ano.currentValue, "");
                _context.PastTagValues.Add(pastValue);
                ano.currentValue = newValue;
            }
            _context.SaveChanges();

            return true;
        }

        public AnalogOutputDTO CreateAnalogOutput(AnalogOutputDTO analogOutputDTO)
        {
            AnalogOutput analogOutput = new AnalogOutput(analogOutputDTO);
            _context.AnalogOutputs.Add(analogOutput);
            _context.SaveChanges();
            return analogOutputDTO;
        }

        AnalogInput ITagRepository.createAnalogInput(AnalogInputDTO analogInputDTO)
        {
            AnalogInput analogInput = new AnalogInput(analogInputDTO);
            _context.AnalogInputs.Add(analogInput);
            _context.SaveChanges();
            return analogInput;
            }

        public DigitalOutputDTO CreateDigitalOutputTag(DigitalOutputDTO digitalTagDto)
        {
            DigitalOutput di = new DigitalOutput(digitalTagDto);
            _context.DigitalOutputs.Add(di);
            _context.SaveChanges();


            return digitalTagDto;
        }

        public DigitalInputDTO CreateDigitalInputTag(DigitalInputDTO digitalTagDto)
        {
            DigitalInput di = new DigitalInput(digitalTagDto);
            _context.DigitalInputs.Add(di);
            _context.SaveChanges();


            return digitalTagDto;
        }

        public bool DeleteInTag(int id, string type)
        {
            if (type.ToLower() == "analoginput")
            {
                var ano = _context.AnalogInputs.Where(x => x.id == id).FirstOrDefault();
                if (ano == null) return false;
                ano.isDeleted = true;
            }
            else
            {
                var ano = _context.DigitalInputs.Where(x => x.id == id).FirstOrDefault();
                if (ano == null) return false;
                ano.isDeleted = true;

                //_context.DigitalOutputs.Remove(ano);
            }
            _context.SaveChanges();
            return true;
        }


        public List<Tag> GetAllTagsWithScanOn()
        {
            var at = this._context.AnalogInputs.Where(x => x.OnOffScan == true && x.isDeleted == false).ToList();
            var dt = this._context.DigitalInputs.Where(x => x.OnOffScan == true && x.isDeleted == false).ToList();

            var tags = new List<Tag>();
            tags.AddRange(at);
            tags.AddRange(dt);
            return tags;
        }
    }


}

