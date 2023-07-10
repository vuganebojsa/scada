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

        public ICollection<Alarm> GetAlarmsByPriority(int priority, SortType sortType)
        {
            var alarms = new List<Alarm>();
            if (sortType == SortType.TimeAsc) {
                 alarms =  _context.Alarms.Where(alarm => alarm.priority == priority).OrderBy(alarm => alarm.timeStamp).ToList();

            }
            else
            {
                 alarms =  _context.Alarms.Where(alarm => alarm.priority == priority).OrderByDescending(alarm => alarm.timeStamp).ToList();
            }
            foreach (Alarm alarm in alarms)
            {
                alarm.analogInput = _context.AnalogInputs.Where(x => x.id == alarm.analogId).FirstOrDefault();
            }
            return alarms;
        }

        public ICollection<Alarm> GetAlarmsInTimePeriod(DateTime from, DateTime to, SortType sortType)
        {
            if (sortType == SortType.TimeAsc)
            {
                return _context.Alarms.Where(alarm => alarm.timeStamp >= from && alarm.timeStamp <= to).OrderBy(alarm => alarm.timeStamp).ToList();
            }else if(sortType == SortType.TimeDesc)
            {
                return _context.Alarms.Where(alarm => alarm.timeStamp >= from && alarm.timeStamp <= to).OrderByDescending(alarm => alarm.timeStamp).ToList();
            }
            else if (sortType == SortType.PriorityAsc)
            {
                return _context.Alarms.Where(alarm => alarm.timeStamp >= from && alarm.timeStamp <= to).OrderBy(alarm => alarm.priority).ToList();
            }
            else
            {
                return _context.Alarms.Where(alarm => alarm.timeStamp >= from && alarm.timeStamp <= to).OrderByDescending(alarm => alarm.priority).ToList();
            }
        }

        public ICollection<PastTagValuesDTO> GetAllTagValuesById(string tagId, SortType sortType)
        {
            var tags = new List<PastTagValuesDTO>();
            var pastTags = new List<PastTagValues>();
            var aiExists = _context.AnalogInputs.Where(
                x => x.id == int.Parse(tagId)).FirstOrDefault();
            if(aiExists != null)
            {
                 pastTags = _context.PastTagValues.Where(
                    x => x.tagId == int.Parse(tagId)).OrderBy(x => x.value).ToList();
            }

            var diExists = _context.DigitalInputs.Where(
                x => x.id == int.Parse(tagId)).FirstOrDefault();
            if (diExists != null)
            {
                 pastTags = _context.PastTagValues.Where(
                   x => x.tagId == int.Parse(tagId)).OrderBy(x => x.value).ToList();
            }
            var aoExists = _context.AnalogOutputs.Where(
                x => x.id == int.Parse(tagId)).FirstOrDefault();
            if (aoExists != null)
            {
                 pastTags = _context.PastTagValues.Where(
                   x => x.tagId == int.Parse(tagId)).OrderBy(x => x.value).ToList();
            }

            var doExists = _context.DigitalOutputs.Where(
                x => x.id == int.Parse(tagId)).FirstOrDefault();
            if (doExists != null)
            {
                pastTags = _context.PastTagValues.Where(
                   x => x.tagId == int.Parse(tagId)).OrderBy(x => x.value).ToList();
            }
            if (pastTags.Any())
            {
                foreach(PastTagValues pt in pastTags){
                    tags.Add(new PastTagValuesDTO(pt.value, pt.timeStamp));
                }
            }
            return tags;
        }

        public ICollection<PastTagValues> GetLastValuesOfAITags(SortType sortType)
        {
            var analogi = _context.AnalogInputs.ToList();
            var tagValues = new List<PastTagValues>();
            foreach (var tag in analogi)
            {
                var val = _context.PastTagValues.Where(x =>
                    x.tagId == tag.id).OrderByDescending(x => x.timeStamp).FirstOrDefault();
                if (val!= null)
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

        public ICollection<PastTagValues> GetLastValuesOfDITags(SortType sortType)
        {
            var digitali = _context.DigitalInputs.ToList();
            var tagValues = new List<PastTagValues>();
            foreach (var tag in digitali)
            {
                var val = _context.PastTagValues.Where(x =>
                    x.tagId == tag.id).OrderByDescending(x => x.timeStamp).FirstOrDefault();
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

        public ICollection<PastTagValues> GetTagsInTimePeriod(DateTime from, DateTime to, SortType sortType)
        {

            var tags = new List<Tag>();
            var tagValues = new List<PastTagValues>();

            // finding all tags so that we can get id's

            var analogi = _context.AnalogInputs.ToList();

            var analogo = _context.AnalogOutputs.ToList();

            var digitali = _context.DigitalInputs.ToList();
            var digitalo = _context.DigitalOutputs.ToList();

            tags.AddRange(analogi);
            tags.AddRange(analogo);
            tags.AddRange(digitali);
            tags.AddRange(digitalo);


            foreach (var tag in tags)
            {
               var vals = _context.PastTagValues.Where(x =>
                    x.tagId == tag.id && x.timeStamp >= from && x.timeStamp <= to).ToList();
                foreach(var val in vals)
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

        ICollection<Alarm> IReportRepository.GetAlarms(string priority)
        {
            throw new NotImplementedException();
        }
    }
}
