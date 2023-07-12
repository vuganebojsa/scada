using scada.DTOS;
using scada.Interfaces;

namespace scada.Services
{
    public class AlarmService : IAlarmService
    {
        private readonly IAlarmRepository _alarmRepository;
        public AlarmService(IAlarmRepository alarmRepository)
        {
            _alarmRepository = alarmRepository;
        }

        public async Task<CreateAlarmDTO> CreateAlarm(CreateAlarmDTO alarm)
        {
            return await this._alarmRepository.CreateAlarm(alarm);
        }
    }
}
