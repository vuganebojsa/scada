using scada.Data;
using scada.Interfaces;
using scada.Models;

namespace scada.Repository
{
    public class AlarmRepositroy : IAlarmRepository
    {
        private readonly DataContext _context;
        public AlarmRepositroy(DataContext context)
        {
            _context = context;
        }

        ICollection<Alarm> IAlarmRepository.GetAllAlarms()
        {
            return _context.Alarms.OrderBy(x => x.Id).ToList();
        }

        ICollection<Alarm> IAlarmRepository.GetAlarmsBetweenTimes(DateTime startTime, DateTime endTime) {

            return _context.Alarms.Where(x => x.timeStamp < endTime && x.timeStamp > startTime).ToList();
        }

        ICollection<Alarm> IAlarmRepository.GetAlarmsByPriority(int priority)
        {
            return _context.Alarms.Where(x => x.priority == priority).ToList();
        }
    }
}