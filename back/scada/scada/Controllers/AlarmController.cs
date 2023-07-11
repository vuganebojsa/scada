using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using scada.DTOS;
using scada.Interfaces;
using scada.Repository;

namespace scada.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlarmController : Controller
    {
        private readonly IAlarmRepository _alarmRepository;
        private readonly IAlarmService _alarmService;
        public AlarmController(IAlarmRepository alarmRepository, IAlarmService alarmService)
        {
            _alarmRepository = alarmRepository;
            _alarmService = alarmService;
        }

        [HttpGet]
        public async Task<IActionResult> getAllAlarms()
        {
            var alarms = await _alarmRepository.GetAllAlarms();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(alarms);
        }
        [HttpGet("activated")]
        public async Task<IActionResult> getAllActivatedAlarms()
        {
            var alarms = await _alarmRepository.GetAllActivatedAlarms();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(alarms);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAlarm([FromBody] CreateAlarmDTO alarm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (alarm.Message.Trim() == "" || alarm.Threshold < 0) return BadRequest("Bad request.");
            if (alarm.Type.ToLower() == "low" || alarm.Type.ToLower() == "high")
            {
                await this._alarmService.CreateAlarm(alarm);

            }
            else
            {
                return BadRequest("Type of alarm must be low/high.");
            }

            return Ok(alarm);
        }

        [HttpGet("getAlarmsByPriority/{priority}")]
        public async Task<IActionResult> getAlarmsByPriority(int priority)
        {
            var alarms = await _alarmRepository.GetAlarmsByPriority(priority);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(alarms);
        }

        [HttpGet("getAlarmsBetweenTimes")]
        public async Task<IActionResult> getAlarmsBetweenTimes(DateTime startDateTime, DateTime endDateTime)
        {
            var alarms = await _alarmRepository.GetAlarmsBetweenTimes(startDateTime, endDateTime);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(alarms);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAlarm([FromQuery]string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isRemoved = await this._alarmRepository.RemoveAlarm(id);

            return Ok(isRemoved);
        }
    }
}
