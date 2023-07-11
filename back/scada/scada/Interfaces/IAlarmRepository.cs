using scada.DTOS;
using scada.Models;

namespace scada.Interfaces
{
    public interface IAlarmRepository
    {
        Task<ICollection<Alarm>> GetAllAlarms();
        Task<ICollection<AlarmActivation>> GetAllActivatedAlarms();
        Task<ICollection<Alarm>> GetAllAlarmsById(int? tagId);
        Task<ICollection<Alarm>> GetAlarmsBetweenTimes(DateTime startTime, DateTime endTime);

        Task<ICollection<Alarm>> GetAlarmsByPriority(int priority);
        Task<CreateAlarmDTO> CreateAlarm(CreateAlarmDTO alarm);
        Task<bool> RemoveAlarm(string id);
        Task AddAlarmActivation(AlarmActivation alarmActivation);
    }
}

