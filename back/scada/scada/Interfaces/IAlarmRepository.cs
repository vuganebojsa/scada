using scada.DTOS;
using scada.Models;

namespace scada.Interfaces
{
    public interface IAlarmRepository
    {
        Task<ICollection<GetAlarmDTO>> GetAllAlarms();
        Task<ICollection<GetActivatedAlarmDTO>> GetAllActivatedAlarms();
        Task<ICollection<Alarm>> GetAllAlarmsById(int? tagId);
        Task<ICollection<Alarm>> GetAlarmsBetweenTimes(DateTime startTime, DateTime endTime);

        Task<ICollection<Alarm>> GetAlarmsByPriority(int priority);
        Task<CreateAlarmDTO> CreateAlarm(CreateAlarmDTO alarm);
        Task<bool> RemoveAlarm(string id);
        Task AddAlarmActivation(AlarmActivation alarmActivation);
    }
}

