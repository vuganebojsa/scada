using scada.DTOS;
using scada.Models;

namespace scada.Interfaces
{
    public interface IAlarmRepository
    {
        ICollection<Alarm> GetAllAlarms();
        ICollection<AlarmActivation> GetAllActivatedAlarms();
        ICollection<Alarm> GetAllAlarmsById(int? tagId);
        ICollection<Alarm> GetAlarmsBetweenTimes(DateTime startTime, DateTime endTime);

        ICollection<Alarm> GetAlarmsByPriority(int priority);
        CreateAlarmDTO CreateAlarm(CreateAlarmDTO alarm);
        bool RemoveAlarm(string id);
        void AddAlarmActivation(AlarmActivation alarmActivation);
    }
}

