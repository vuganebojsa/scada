using scada.DTOS;
using scada.Models;

namespace scada.Interfaces
{
    public interface IAlarmRepository
    {
        ICollection<Alarm> GetAllAlarms();
        ICollection<Alarm> GetAlarmsBetweenTimes(DateTime startTime, DateTime endTime);

        ICollection<Alarm> GetAlarmsByPriority(int priority);
        CreateAlarmDTO CreateAlarm(CreateAlarmDTO alarm);
        bool RemoveAlarm(string id);
    }
}

