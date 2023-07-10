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
            if (analogTagDto.currentValue > analogTagDto.HighLimit || analogTagDto.currentValue < analogTagDto.LowLimit || analogTagDto.HighLimit < analogTagDto.LowLimit) return BadRequest("Invalid tag value");
            if (analogTagDto.ScanTime < 0) return BadRequest("Invalid scan time");
            AnalogInput ai = _tagService.createAnalogInput(analogTagDto);
            
            return Ok(ai);
        }
        [HttpPost("createDigitalInputTag")]
        public IActionResult createDigitalInputTag([FromBody] DigitalInputDTO digitalTagDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (digitalTagDto.initialValue > 1 || digitalTagDto.initialValue < 0) return BadRequest("Invalid tag value");
            if (digitalTagDto.ScanTime < 0) return BadRequest("Invalid scan time");
            var tag = this._tagService.CreateDigitalInputTag(digitalTagDto);
            return Ok(tag);
        }
        [HttpPost("createDigitalOutputTag")]
        public IActionResult createDigitalOutputTag([FromBody] DigitalOutputDTO digitalTagDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (digitalTagDto.InitialValue > 1 || digitalTagDto.InitialValue < 0) return BadRequest("Invalid tag value");
            var tag = this._tagService.CreateDigitalOutputTag(digitalTagDto);

            return Ok(tag);
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

        [HttpDelete("inTags")]
        public IActionResult DeleteInTag(
           [FromQuery] int id,
           [FromQuery] string type)
        {
            bool isDeleted = _tagService.DeleteInTag(id, type);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(isDeleted);
        }

        [HttpGet("analogInputTags")]
        public IActionResult GetAnalogInputTags()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tags = _tagRepository.GetAnalogInputTags();

            return Ok(tags);
        }

        [HttpGet("trendingTags")]
        public IActionResult GetAllTagsScanOn()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            List<Tag> tags = _tagRepository.GetAllTagsWithScanOn();

            return Ok(tags);
        }

        [HttpPut("outTagsValue")]
        public IActionResult outTagsValueChange(
            [FromBody] OutTagsValueDTO outTagsValueDto)
        {
            var setScan = _tagService.SetValue(outTagsValueDto.Id, outTagsValueDto.Type, outTagsValueDto.Value);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(setScan);
        }
    }
}
