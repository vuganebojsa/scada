using scada.DTOS;

namespace scada.Interfaces
{
    public interface IAlarmService
    {

        Task<CreateAlarmDTO> CreateAlarm(CreateAlarmDTO alarm);
    }
}
