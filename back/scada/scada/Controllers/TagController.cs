using Microsoft.AspNetCore.Mvc;
using scada.DTOS;
using scada.Interfaces;
using scada.Models;
using scada.Repository;

namespace scada.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : Controller
    {
        private readonly ITagRepository _tagRepository;
        private readonly ITagService _tagService;
        public TagController(ITagRepository tagRepository, ITagService tagService)
        {
            _tagRepository = tagRepository;
            _tagService = tagService;
        }

        [HttpGet]
        public IActionResult GetTags()
        {
            var tags = _tagRepository.GetTags();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(tags);
        }
        [HttpGet("outTags")]
        public IActionResult GetOutTags()
        {
            var tags = _tagService.GetOutTags();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(tags);
        }
        [HttpDelete("outTags")]
        public IActionResult DeleteOutTag(
            [FromQuery]int id, 
            [FromQuery] string type)
        {
            var isDeleted = _tagService.DeleteOutTag(id, type);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(isDeleted);
        }
        [HttpPost("createAnalogInputTag")]
        public IActionResult createAnalogInputTag([FromBody] AnalogInputDTO analogTagDto)
        {
            
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            AnalogInput ai = new AnalogInput(analogTagDto);
            
            return Ok(ai);
        }
        [HttpPost("createDigitalInputTag")]
        public IActionResult createDigitalInputTag([FromBody] DigitalInputDTO digitalTagDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            DigitalInput di = new DigitalInput(digitalTagDto);

            return Ok(di);
        }
        [HttpPost("createDigitalOutputTag")]
        public IActionResult createDigitalOutputTag([FromBody] DigitalOutputDTO digitalTagDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            DigitalOutput dO = new DigitalOutput(digitalTagDto);

            return Ok(dO);
        }
        [HttpPost("createAnalogOutputTag")]
        public IActionResult createAnalogOutputTag([FromBody] AnalogOutputDTO analogTagDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            if(analogTagDto.LowLimit > analogTagDto.HighLimit)
            {
                return BadRequest("Low Limit must be below High limit");
            }

            if (analogTagDto.InitialValue < analogTagDto.LowLimit || analogTagDto.InitialValue > analogTagDto.HighLimit)
            {
                return BadRequest("initial value must be in between high limit and low limit");
            }

            this._tagService.CreateOutputTag(analogTagDto);

            return Ok(analogTagDto);
        }

        [HttpGet("inTags")]
        public IActionResult GetInTags()
        {
            var tags = _tagService.GetInTags();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(tags);
        }
        [HttpPut("inTagsScan")]
        public IActionResult InTagsScanOnOff(
            [FromBody]InTagsScanDTO inTagsScanDTO)
        {
            var setScan = _tagService.SetScan(inTagsScanDTO.Id, inTagsScanDTO.Type, inTagsScanDTO.IsOn);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(setScan);
        }
    }
}
