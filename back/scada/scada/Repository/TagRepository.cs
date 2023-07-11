using Microsoft.VisualBasic;
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

        async Task<ICollection<Tag>> GetTags()
        {
            await Global._semaphore.WaitAsync();
            try
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
            finally
            {
                Global._semaphore.Release();
            }

        }
        async Task< AnalogInput> GetAnalogInputById(int id)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                return _context.AnalogInputs.Where(x => x.id == id).FirstOrDefault();
            }
            finally { Global._semaphore.Release(); }
        }
        async Task< DigitalInput> GetDigitalInputById(int id)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                return _context.DigitalInputs.Where(x => x.id == id).FirstOrDefault();
            }
            finally { Global._semaphore.Release(); }
        }
        async Task< AnalogOutput> GetAnalogOutputById(int id)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                return _context.AnalogOutputs.Where(x => x.id == id).FirstOrDefault();
            }
            finally { Global._semaphore.Release(); }
        }
        async Task< DigitalOutput> GetDigitalOutputById(int id)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                return _context.DigitalOutputs.Where(x => x.id == id).FirstOrDefault();
            }
            finally { Global._semaphore.Release(); }
        }

        async Task< ICollection<AnalogInput>> GetAnalogInputTags() {
            await Global._semaphore.WaitAsync();
            try
            {
                return _context.AnalogInputs.Where(x => x.isDeleted == false).OrderBy(x => x.id).ToList();
            }
            finally { Global._semaphore.Release(); }
        }

        async Task< ICollection<DigitalInput>> GetDigitalInputTags()
        {
            await Global._semaphore.WaitAsync();
            try
            {
                return _context.DigitalInputs.Where(x => x.isDeleted == false).OrderBy(x => x.id).ToList();
            }
            finally { Global._semaphore.Release(); }
        }

        async Task< ICollection<Tag>> GetOutTags()
        {
            await Global._semaphore.WaitAsync();
            try
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
            finally { Global._semaphore.Release(); }
        }

        async Task< bool> DeleteOutTag(int id, string type)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                if (type.ToLower() == "analogoutput")
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
            finally { Global._semaphore.Release(); }
        }

        async Task< ICollection<Tag>> GetInTags()
        {
            await Global._semaphore.WaitAsync();
            try
            {
                var analogo = _context.AnalogInputs.ToList();
                var digitalo = _context.DigitalInputs.ToList();
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
            finally { Global._semaphore.Release(); }
        }

        async Task< bool> SetScan(int id, string type, bool isOn)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                if (type.ToLower() == "digitalinput")
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
            finally { Global._semaphore.Release(); }
        }

        async Task< bool> SetValue(int id, string type, int newValue)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                if (type.ToLower() == "digitaloutput")
                {
                    var ano = _context.DigitalOutputs.Where(x => x.id == id).FirstOrDefault();
                    if (ano == null) return false;
                    if (newValue != 0 && newValue != 1)
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
            finally { Global._semaphore.Release(); }
        }

        async Task< AnalogOutputDTO> CreateAnalogOutput(AnalogOutputDTO analogOutputDTO)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                AnalogOutput analogOutput = new AnalogOutput(analogOutputDTO);
                _context.AnalogOutputs.Add(analogOutput);
                _context.SaveChanges();
                return analogOutputDTO;
            }
            finally { Global._semaphore.Release(); }
        }

        async Task<AnalogInput> createAnalogInput(AnalogInputDTO analogInputDTO)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                AnalogInput analogInput = new AnalogInput(analogInputDTO);
                _context.AnalogInputs.Add(analogInput);
                _context.SaveChanges();
                return analogInput;
            }
            finally { Global._semaphore.Release(); }
            }
         

        async Task<DigitalOutputDTO> CreateDigitalOutputTag(DigitalOutputDTO digitalTagDto)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                DigitalOutput di = new DigitalOutput(digitalTagDto);
                _context.DigitalOutputs.Add(di);
                _context.SaveChanges();


                return digitalTagDto;
            }
            finally { Global._semaphore.Release(); }
        }

        async Task<DigitalInputDTO> CreateDigitalInputTag(DigitalInputDTO digitalTagDto)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                DigitalInput di = new DigitalInput(digitalTagDto);
                _context.DigitalInputs.Add(di);
                _context.SaveChanges();


                return digitalTagDto;
            }
            finally { Global._semaphore.Release(); }
        }

        async Task< bool> DeleteInTag(int id, string type)
        {
            await Global._semaphore.WaitAsync();
            try
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
            finally { Global._semaphore.Release(); }
        }


        async Task< List<Tag>> GetAllTagsWithScanOn()
        {
            await Global._semaphore.WaitAsync();
            try
            {
                var at = this._context.AnalogInputs.Where(x => x.OnOffScan == true && x.isDeleted == false).ToList();
                var dt = this._context.DigitalInputs.Where(x => x.OnOffScan == true && x.isDeleted == false).ToList();

                var tags = new List<Tag>();
                tags.AddRange(at);
                tags.AddRange(dt);
                return tags;
            }
            finally { Global._semaphore.Release(); }
        }

        public async void CreatePastTagValue(PastTagValues pastTagValues)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                await Task.Delay(1);
                _context.PastTagValues.Add(pastTagValues);

                await _context.SaveChangesAsync();
            }
            finally
            {
                Global._semaphore.Release();
            }
            
        }

        public async void UpdateAnalogInput(AnalogInput analogInput)
        {

            await Global._semaphore.WaitAsync();
            try
            {
                var ai = await _context.AnalogInputs.FindAsync(analogInput.id);
                ai.currentValue = analogInput.currentValue;

                await _context.SaveChangesAsync();
            }
            finally
            {
                Global._semaphore.Release();
            }
         
        }

        public async void UpdateDigitalInput(DigitalInput digitalInput)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                var ai = await _context.DigitalInputs.FindAsync(digitalInput.id);
                ai.currentValue = digitalInput.currentValue;

                await _context.SaveChangesAsync();
            }
            finally
            {
                Global._semaphore.Release();
            }
        }
    }


}

