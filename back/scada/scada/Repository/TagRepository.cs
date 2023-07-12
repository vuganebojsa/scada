using Microsoft.EntityFrameworkCore;
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

        public async Task<ICollection<Tag>> GetTags()
        {
            await Global._semaphore.WaitAsync();
            try
            {

                ICollection<Tag> tags = new HashSet<Tag>();

           
                foreach (var item in await _context.AnalogInputs.OrderBy(x => x.id).ToListAsync())
                {
                    item.Alarms = await _context.Alarms.Where(x => x.analogId == item.id).ToListAsync();
                    tags.Add(item);

                }
                foreach (var item in await _context.AnalogOutputs.OrderBy(x => x.id).ToListAsync())
                {
                    tags.Add(item);
                }
                foreach (var item in await _context.DigitalInputs.OrderBy(x => x.id).ToListAsync())
                {
                    tags.Add(item);
                }
                foreach (var item in await _context.DigitalOutputs.OrderBy(x => x.id).ToListAsync())
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
        public async Task< AnalogInput> GetAnalogInputById(int id)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                return await _context.AnalogInputs.Where(x => x.id == id).FirstOrDefaultAsync();
            }
            finally { Global._semaphore.Release(); }
        }
        public async Task< DigitalInput> GetDigitalInputById(int id)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                return await _context.DigitalInputs.Where(x => x.id == id).FirstOrDefaultAsync();
            }
            finally { Global._semaphore.Release(); }
        }
        public async Task< AnalogOutput> GetAnalogOutputById(int id)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                return await  _context.AnalogOutputs.Where(x => x.id == id).FirstOrDefaultAsync();
            }
            finally { Global._semaphore.Release(); }
        }
        public async Task< DigitalOutput> GetDigitalOutputById(int id)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                return await _context.DigitalOutputs.Where(x => x.id == id).FirstOrDefaultAsync();
            }
            finally { Global._semaphore.Release(); }
        }

        public async Task< ICollection<AnalogInput>> GetAnalogInputTags() {
            await Global._semaphore.WaitAsync();
            try
            {
                return await _context.AnalogInputs.Where(x => x.isDeleted == false).OrderBy(x => x.id).ToListAsync();
            }
            finally { Global._semaphore.Release(); }
        }

        public async Task< ICollection<DigitalInput>> GetDigitalInputTags()
        {
            await Global._semaphore.WaitAsync();
            try
            {
                return await _context.DigitalInputs.Where(x => x.isDeleted == false).OrderBy(x => x.id).ToListAsync();
            }
            finally { Global._semaphore.Release(); }
        }

        public async Task< ICollection<Tag>> GetOutTags()
        {
            await Global._semaphore.WaitAsync();
            try
            {

                var analogo = await _context.AnalogOutputs.ToListAsync();
                var digitalo =await _context.DigitalOutputs.ToListAsync();
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

        public async Task< bool> DeleteOutTag(int id, string type)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                if (type.ToLower() == "analogoutput")
                {
                    var ano = await _context.AnalogOutputs.Where(x => x.id == id).FirstOrDefaultAsync();
                    if (ano == null) return false;
                    ano.isDeleted = true;
                }
                else
                {
                    var ano =await _context.DigitalOutputs.Where(x => x.id == id).FirstOrDefaultAsync();
                    if (ano == null) return false;
                    ano.isDeleted = true;

                    //_context.DigitalOutputs.Remove(ano);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            finally { Global._semaphore.Release(); }
        }

        public async Task< ICollection<Tag>> GetInTags()
        {
            await Global._semaphore.WaitAsync();
            try
            {
                var analogo = await _context.AnalogInputs.ToListAsync();
                var digitalo = await _context.DigitalInputs.ToListAsync();
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

        public async Task< bool> SetScan(int id, string type, bool isOn)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                if (type.ToLower() == "digitalinput")
                {
                    var ano =await _context.DigitalInputs.Where(x => x.id == id).FirstOrDefaultAsync();
                    if (ano == null) return false;
                    ano.OnOffScan = isOn;

                }
                else
                {
                    var ano =await _context.AnalogInputs.Where(x => x.id == id).FirstOrDefaultAsync();
                    if (ano == null) return false;
                    ano.OnOffScan = isOn;
                }
                await _context.SaveChangesAsync();

                return true;
            }
            finally { Global._semaphore.Release(); }
        }

        public async Task<bool> SetValue(int id, string type, int newValue)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                if (type.ToLower() == "digitaloutput")
                {
                    var ano =await _context.DigitalOutputs.Where(x => x.id == id).FirstOrDefaultAsync();
                    if (ano == null) return false;
                    if (newValue != 0 && newValue != 1)
                    {
                        return false;
                    }
                    PastTagValues pastValue = new PastTagValues(ano, ano.currentValue, "");
                    await _context.PastTagValues.AddAsync(pastValue);
                    ano.currentValue = newValue;
                    if (ano.description == null) ano.description = "";


                }
                else
                {
                    var ano = await _context.AnalogOutputs.Where(x => x.id == id).FirstOrDefaultAsync();
                    if (ano == null) return false;
                    if (newValue > ano.HighLimit || newValue < ano.LowLimit)
                    {
                        return false;
                    }
                    PastTagValues pastValue = new PastTagValues(ano, ano.currentValue, "");
                    await _context.PastTagValues.AddAsync(pastValue);
                    ano.currentValue = newValue;
                    if (ano.description == null) ano.description = "";
                }
                await _context.SaveChangesAsync();

                return true;
            }
            finally { Global._semaphore.Release(); }
        }

        public async Task< AnalogOutputDTO> CreateAnalogOutput(AnalogOutputDTO analogOutputDTO)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                AnalogOutput analogOutput = new AnalogOutput(analogOutputDTO);
                await _context.AnalogOutputs.AddAsync(analogOutput);
                await _context.SaveChangesAsync();
                return analogOutputDTO;
            }
            finally { Global._semaphore.Release(); }
        }

        public async Task<AnalogInput> createAnalogInput(AnalogInputDTO analogInputDTO)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                AnalogInput analogInput = new AnalogInput(analogInputDTO);
                await _context.AnalogInputs.AddAsync(analogInput);
                await _context.SaveChangesAsync();
                return analogInput;
            }
            finally { Global._semaphore.Release(); }
            }


        public async Task<DigitalOutputDTO> CreateDigitalOutputTag(DigitalOutputDTO digitalTagDto)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                DigitalOutput di = new DigitalOutput(digitalTagDto);
                await _context.DigitalOutputs.AddAsync(di);
                await _context.SaveChangesAsync();


                return digitalTagDto;
            }
            finally { Global._semaphore.Release(); }
        }

        public async Task<DigitalInputDTO> CreateDigitalInputTag(DigitalInputDTO digitalTagDto)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                DigitalInput di = new DigitalInput(digitalTagDto);
                await _context.DigitalInputs.AddAsync(di);
                await _context.SaveChangesAsync();


                return digitalTagDto;
            }
            finally { Global._semaphore.Release(); }
        }

        public async Task< bool> DeleteInTag(int id, string type)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                if (type.ToLower() == "analoginput")
                {
                    var ano = await _context.AnalogInputs.Where(x => x.id == id).FirstOrDefaultAsync();
                    if (ano == null) return false;
                    ano.isDeleted = true;
                }
                else
                {
                    var ano =await _context.DigitalInputs.Where(x => x.id == id).FirstOrDefaultAsync();
                    if (ano == null) return false;
                    ano.isDeleted = true;

                    //_context.DigitalOutputs.Remove(ano);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            finally { Global._semaphore.Release(); }
        }


        public async Task< List<Tag>> GetAllTagsWithScanOn()
        {
            await Global._semaphore.WaitAsync();
            try
            {
                var at =await this._context.AnalogInputs.Where(x => x.OnOffScan == true && x.isDeleted == false).ToListAsync();
                var dt =await this._context.DigitalInputs.Where(x => x.OnOffScan == true && x.isDeleted == false).ToListAsync();

                var tags = new List<Tag>();
                tags.AddRange(at);
                tags.AddRange(dt);
                return tags;
            }
            finally { Global._semaphore.Release(); }
        }

        public async Task CreatePastTagValue(PastTagValues pastTagValues)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                await Task.Delay(1);
                await _context.PastTagValues.AddAsync(pastTagValues);

                await _context.SaveChangesAsync();
            }
            finally
            {
                Global._semaphore.Release();
            }
            
        }

        public async Task UpdateAnalogInput(AnalogInput analogInput)
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

        public async Task UpdateDigitalInput(DigitalInput digitalInput)
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

