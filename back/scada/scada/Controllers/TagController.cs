using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using scada.DTOS;
using scada.Interfaces;
using scada.Models;
using scada.Repository;
using System.ComponentModel.DataAnnotations;

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

        [Authorize]
        [HttpGet]
        public async Task< IActionResult> GetTags()
        {
            var tags =await _tagRepository.GetTags();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(tags);
        }
        [Authorize]
        [HttpGet("outTags")]
        public async Task<IActionResult> GetOutTags()
        {
            var tags =await _tagService.GetOutTags();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(tags);
        }
        [Authorize(Roles ="admin")]
        [HttpDelete("outTags")]
        public async Task<IActionResult> DeleteOutTag(
            [FromQuery]int id, 
            [FromQuery] string type)
        {
            var isDeleted =await _tagService.DeleteOutTag(id, type);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(isDeleted);
        }
        [Authorize(Roles = "admin")]
        [HttpPost("createAnalogInputTag")]
        public async Task<IActionResult> createAnalogInputTag([FromBody] AnalogInputDTO analogTagDto)
        {
            
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (analogTagDto.currentValue > analogTagDto.HighLimit || analogTagDto.currentValue < analogTagDto.LowLimit || analogTagDto.HighLimit < analogTagDto.LowLimit) return BadRequest("Invalid tag value");
            if (analogTagDto.ScanTime < 0) return BadRequest("Invalid scan time");
            AnalogInput ai =await _tagService.createAnalogInput(analogTagDto);
            
            return Ok(ai);
        }
        [Authorize(Roles = "admin")]
        [HttpPost("createDigitalInputTag")]
        public async Task<IActionResult> createDigitalInputTag([FromBody] DigitalInputDTO digitalTagDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (digitalTagDto.initialValue > 1 || digitalTagDto.initialValue < 0) return BadRequest("Invalid tag value");
            if (digitalTagDto.ScanTime < 0) return BadRequest("Invalid scan time");
            var tag =await this._tagService.CreateDigitalInputTag(digitalTagDto);
            return Ok(tag);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("createDigitalOutputTag")]
        public async Task<IActionResult> createDigitalOutputTag([FromBody] DigitalOutputDTO digitalTagDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (digitalTagDto.InitialValue > 1 || digitalTagDto.InitialValue < 0) return BadRequest("Invalid tag value");
            var tag =await this._tagService.CreateDigitalOutputTag(digitalTagDto);

            return Ok(tag);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("createAnalogOutputTag")]
        public async Task<IActionResult> createAnalogOutputTag([FromBody] AnalogOutputDTO analogTagDto)
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

            await this._tagService.CreateOutputTag(analogTagDto);

            return Ok(analogTagDto);
        }

        [Authorize]
        [HttpGet("inTags")]
        public async Task<IActionResult> GetInTags()
        {
            var tags = await _tagService.GetInTags();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(tags);
        }
        [Authorize(Roles = "admin")]
        [HttpPut("inTagsScan")]
        public async Task<IActionResult> InTagsScanOnOff(
            [FromBody]InTagsScanDTO inTagsScanDTO)
        {
            var setScan =await _tagService.SetScan(inTagsScanDTO.Id, inTagsScanDTO.Type, inTagsScanDTO.IsOn);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(setScan);
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("inTags")]
        public async Task<IActionResult> DeleteInTag(
           [FromQuery] int id,
           [FromQuery] string type)
        {
            bool isDeleted =await _tagService.DeleteInTag(id, type);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(isDeleted);
        }
        [Authorize]
        [HttpGet("analogInputTags")]
        public async Task<IActionResult> GetAnalogInputTags()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tags =await _tagRepository.GetAnalogInputTags();

            return Ok(tags);
        }
        [Authorize]
        [HttpGet("trendingTags")]
        public async Task<IActionResult> GetAllTagsScanOn()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            List<Tag> tags =await _tagRepository.GetAllTagsWithScanOn();

            return Ok(tags);
        }
        [Authorize(Roles = "admin")]
        [HttpPut("outTagsValue")]
        public async Task<IActionResult> outTagsValueChange(
            [FromBody] OutTagsValueDTO outTagsValueDto)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            AnalogOutput ao =await _tagRepository.GetAnalogOutputById(outTagsValueDto.Id);
            if(ao == null)
            {
                DigitalOutput dO =await _tagRepository.GetDigitalOutputById(outTagsValueDto.Id);
                if(dO == null)
                {
                    return BadRequest("Tag with that Id does not exist");
                }
                if (outTagsValueDto.Value!= 0 && outTagsValueDto.Value != 1) {
                    return BadRequest("Digital output must be 0 or 1");
                }
            }
            else
            {
                if (ao.HighLimit < outTagsValueDto.Value)
                {
                    return BadRequest("Value can not be higher than high limit of a tag");
                }
                if (ao.LowLimit > outTagsValueDto.Value)
                {
                    return BadRequest("Value can not be lower than low limit of a tag");
                }
            }
            
            var setScan =await _tagService.SetValue(outTagsValueDto.Id, outTagsValueDto.Type, outTagsValueDto.Value);
            return Ok(setScan);
        }
    }
}
