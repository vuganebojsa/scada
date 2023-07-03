using scada.Models;

namespace scada.Interfaces
{
    public interface IAlarmRepository
    {
        ICollection<Alarm> GetAllAlarms();
        ICollection<Alarm> GetAlarmsBetweenTimes(DateTime startTime, DateTime endTime);

        ICollection<Alarm> GetAlarmsByPriority(int priority);

    }
}

