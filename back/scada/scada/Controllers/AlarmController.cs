using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using scada.Interfaces;
using scada.Repository;

namespace scada.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlarmController : Controller
    {
        private readonly IAlarmRepository _alarmRepository;
        public AlarmController(IAlarmRepository alarmRepository)
        {
            _alarmRepository = alarmRepository;
        }

        [HttpGet]
        public IActionResult getAllAlarms()
        {
            var alarms = _alarmRepository.GetAllAlarms();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(alarms);
        }

        [HttpGet("getAlarmsByPriority/{priority}")]
        public IActionResult getAlarmsByPriority(int priority)
        {
            var alarms = _alarmRepository.GetAlarmsByPriority(priority);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(alarms);
        }

        [HttpGet("getAlarmsBetweenTimes")]
        public IActionResult getAlarmsBetweenTimes(DateTime startDateTime, DateTime endDateTime)
        {
            var alarms = _alarmRepository.GetAlarmsBetweenTimes(startDateTime, endDateTime);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(alarms);
        }
    }
}
