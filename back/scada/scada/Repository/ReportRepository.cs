using Microsoft.EntityFrameworkCore;
using scada.Data;
using scada.DTOS;
using scada.Enums;
using scada.Interfaces;
using scada.Models;

namespace scada.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly DataContext _context;
        public ReportRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Alarm>> GetAlarmsByPriority(int priority, SortType sortType)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                var alarms = new List<Alarm>();
                if (sortType == SortType.TimeAsc)
                {
                    alarms = await _context.Alarms.Where(alarm => alarm.priority == priority).OrderBy(alarm => alarm.timeStamp).ToListAsync();

                }
                else
                {
                    alarms = await _context.Alarms.Where(alarm => alarm.priority == priority).OrderByDescending(alarm => alarm.timeStamp).ToListAsync();
                }
                foreach (Alarm alarm in alarms)
                {
                    alarm.analogInput = await _context.AnalogInputs.FindAsync(alarm.analogId);
                }
                return alarms;
            }
            finally
            {
                Global._semaphore.Release();
            }
        }

        public async Task<ICollection<Alarm>> GetAlarmsInTimePeriod(DateTime from, DateTime to, SortType sortType)

        {
            await Global._semaphore.WaitAsync();
            try
            {
                var als = new List<AlarmActivation>();


                if (sortType == SortType.TimeAsc)
                {
                    als = await _context.AlarmActivations.Where(alarm => alarm.Timestamp >= from && alarm.Timestamp <= to).OrderBy(alarm => alarm.Timestamp).ToListAsync();
                }
                else if (sortType == SortType.TimeDesc)
                {
                    als = await _context.AlarmActivations.Where(alarm => alarm.Timestamp >= from && alarm.Timestamp <= to).OrderByDescending(alarm => alarm.Timestamp).ToListAsync();
                }
                else if (sortType == SortType.PriorityAsc)
                {
                    als = await _context.AlarmActivations.Where(alarm => alarm.Timestamp >= from && alarm.Timestamp <= to).OrderBy(alarm => alarm.alarm.priority).ToListAsync();
                }
                else
                {
                    als = await _context.AlarmActivations.Where(alarm => alarm.Timestamp >= from && alarm.Timestamp <= to).OrderByDescending(alarm => alarm.alarm.priority).ToListAsync();

                }
                var alarms = new List<Alarm>();

                foreach (var al in als)
                {
                    alarms.Add(await _context.Alarms.FindAsync(al.alarmId));
                }
                return alarms;
            }
            finally
            {
                Global._semaphore.Release();
            }
        }

        public async Task<ICollection<PastTagValuesDTO>> GetAllTagValuesById(string tagId, SortType sortType)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                var tags = new List<PastTagValuesDTO>();
                var pastTags = new List<PastTagValues>();
                var aiExists = await _context.AnalogInputs.FindAsync(
                    int.Parse(tagId));
                if (aiExists != null)
                {
                    pastTags = await _context.PastTagValues.Where(
                       x => x.tagId == int.Parse(tagId)).OrderBy(x => x.value).ToListAsync();
                }

                var diExists = await _context.DigitalInputs.Where(
                    x => x.id == int.Parse(tagId)).FirstOrDefaultAsync();
                if (diExists != null)
                {
                    pastTags = await _context.PastTagValues.Where(
                      x => x.tagId == int.Parse(tagId)).OrderBy(x => x.value).ToListAsync();
                }
                var aoExists = _context.AnalogOutputs.Where(
                    x => x.id == int.Parse(tagId)).FirstOrDefault();
                if (aoExists != null)
                {
                    pastTags = await _context.PastTagValues.Where(
                      x => x.tagId == int.Parse(tagId)).OrderBy(x => x.value).ToListAsync();
                }

                var doExists = await _context.DigitalOutputs.FindAsync(
                     int.Parse(tagId));
                if (doExists != null)
                {
                    pastTags = await _context.PastTagValues.Where(
                       x => x.tagId == int.Parse(tagId)).OrderBy(x => x.value).ToListAsync();
                }
                if (pastTags.Any())
                {
                    foreach (PastTagValues pt in pastTags)
                    {
                        tags.Add(new PastTagValuesDTO(pt.value, pt.timeStamp, pt.tag.tagName));
                    }
                }
                return tags;
            }
            finally
            {
                Global._semaphore.Release();
            }
        }

        public async Task<ICollection<PastTagValues>> GetLastValuesOfAITags(SortType sortType)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                var analogi = await _context.AnalogInputs.ToListAsync();
                var tagValues = new List<PastTagValues>();
                foreach (var tag in analogi)
                {
                    var val = await _context.PastTagValues.Where(x =>
                        x.tagId == tag.id).OrderByDescending(x => x.timeStamp).FirstOrDefaultAsync();
                    if (val != null)
                    {
                        val.tag = new Tag();
                        val.tag.tagName = tag.tagName;
                        tagValues.Add(val);
                    }


                }
                if (sortType == SortType.TimeAsc)
                {
                    tagValues = tagValues.OrderBy(x => x.timeStamp).ToList();
                }
                else
                {
                    tagValues = tagValues.OrderByDescending(x => x.timeStamp).ToList();

                }
                return tagValues;
            }
            finally
            {
                Global._semaphore.Release();
            }

        }

        public async Task<ICollection<PastTagValues>> GetLastValuesOfDITags(SortType sortType)
        {

            await Global._semaphore.WaitAsync();
            try
            {
                var digitali = _context.DigitalInputs.ToList();
                var tagValues = new List<PastTagValues>();
                foreach (var tag in digitali)
                {
                    var val = await _context.PastTagValues.Where(x =>
                        x.tagId == tag.id).OrderByDescending(x => x.timeStamp).FirstOrDefaultAsync();
                    if (val != null)
                    {
                        val.tag = new Tag();
                        val.tag.tagName = tag.tagName;
                        tagValues.Add(val);
                    }
                }
                if (sortType == SortType.TimeAsc)
                {
                    tagValues = tagValues.OrderBy(x => x.timeStamp).ToList();
                }
                else
                {
                    tagValues = tagValues.OrderByDescending(x => x.timeStamp).ToList();

                }
                return tagValues;
            }
            finally
            {
                Global._semaphore.Release();
            }
        }

        public async Task<ICollection<PastTagValues>> GetTagsInTimePeriod(DateTime from, DateTime to, SortType sortType)
        {

            await Global._semaphore.WaitAsync();
            try
            {
                var tags = new List<Tag>();
                var tagValues = new List<PastTagValues>();

                // finding all tags so that we can get id's

                var analogi = await _context.AnalogInputs.ToListAsync();

                var analogo = await _context.AnalogOutputs.ToListAsync();

                var digitali = await _context.DigitalInputs.ToListAsync();
                var digitalo = await _context.DigitalOutputs.ToListAsync();

                tags.AddRange(analogi);
                tags.AddRange(analogo);
                tags.AddRange(digitali);
                tags.AddRange(digitalo);


                foreach (var tag in tags)
                {
                    var vals = await _context.PastTagValues.Where(x =>
                         x.tagId == tag.id && x.timeStamp >= from && x.timeStamp <= to).ToListAsync();
                    foreach (var val in vals)
                    {
                        val.tag = new Tag();
                        val.tag.tagName = tag.tagName;
                    }
                    tagValues.AddRange(vals);
                }


                if (sortType == SortType.TimeAsc)
                {

                    tagValues = tagValues.OrderBy(x => x.timeStamp).ToList();
                }
                else
                {
                    tagValues = tagValues.OrderByDescending(x => x.timeStamp).ToList();

                }
                return tagValues;
            }
            finally
            {
                Global._semaphore.Release();
            }
        }

        public async Task<ICollection<Alarm>> GetAlarms(string priority)
        {
            throw new NotImplementedException();
        }
    }
}
