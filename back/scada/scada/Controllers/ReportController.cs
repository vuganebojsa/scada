using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using scada.Enums;
using scada.Interfaces;

namespace scada.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("getAlarmsInTimePeriod/")]
        public IActionResult GetAlarmsInTimePeriod(
            [FromQuery]DateTime from, 
            [FromQuery] DateTime to, 
            [FromQuery] SortType sortType)
        {
            var alarms = this._reportService.GetAlarmsInTimePeriod(from, to, sortType);
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(alarms);

        }

        [HttpGet("getAlarmsByPriority/")]
        public IActionResult GetAlarmsByPriority(
            [FromQuery]int priority, 
            [FromQuery]SortType sortType)
        {
            var alarms = this._reportService.GetAlarmsByPriority(priority, sortType);
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(alarms);
        }

        [HttpGet("getTagsInTimePeriod/")]
        public IActionResult GetTagsByInTimePeriod(
            [FromQuery] DateTime from,
            [FromQuery] DateTime to,
            [FromQuery] SortType sortType)
        {
            var tags = this._reportService.GetTagsInTimePeriod(from, to, sortType);
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(tags);
        }

        [HttpGet("getLastValuesOfAiTags/")]
        public IActionResult GetLastValuesOfAITags(
            [FromQuery] SortType sortType)
        {
            var tags = this._reportService.GetLastValuesOfAITags(sortType);
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(tags);
        }

        [HttpGet("getLastValuesOfDiTags/")]
        public IActionResult GetLastValuesOfDITags(
           [FromQuery] SortType sortType)
        {
            var tags = this._reportService.GetLastValuesOfDITags(sortType);
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(tags);
        }

        [HttpGet("getAllTagsById/")]
        public IActionResult GetAllTagsById(
           [FromQuery] string tagId,
           [FromQuery] SortType sortType)
        {
            var tags = this._reportService.GetTagValuesById(tagId, sortType);
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(tags);
        }




    }
}
