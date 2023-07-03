using scada.Data;
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
            if (sortType == SortType.TimeAsc) {
                return _context.Alarms.Where(alarm => alarm.priority == priority).OrderBy(alarm => alarm.timeStamp).ToList();
            }
            else
            {
                return _context.Alarms.Where(alarm => alarm.priority == priority).OrderByDescending(alarm => alarm.timeStamp).ToList();
            }
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

        public ICollection<Tag> GetAllTagValuesById(string tagId, SortType sortType)
        {
            throw new NotImplementedException();
        }

        public ICollection<Tag> GetLastValuesOfAITags(SortType sortType)
        {
            throw new NotImplementedException();
        }

        public ICollection<Tag> GetLastValuesOfDITags(SortType sortType)
        {
            throw new NotImplementedException();
        }

        public ICollection<Tag> GetTagsInTimePeriod(DateTime from, DateTime to, SortType sortType)
        {

            throw new NotImplementedException();
        }

        ICollection<Alarm> GetAlarms(string priority)
        {
            throw new NotImplementedException();
        }

        ICollection<Alarm> IReportRepository.GetAlarms(string priority)
        {
            throw new NotImplementedException();
        }
    }
}
