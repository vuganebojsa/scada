using scada.DTOS;

namespace scada.Interfaces
{
    public interface IAlarmService
    {

        CreateAlarmDTO CreateAlarm(CreateAlarmDTO alarm);
    }
}
