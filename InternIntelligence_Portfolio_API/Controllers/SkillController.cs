using Bussines.Abstarct;
using Entities.DTOs.SkillDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InternIntelligence_Portfolio_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting("Fixed")]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }
        [HttpGet("[action]")]
        public IActionResult GetSkillForUI()
        {
            var result = _skillService.GetSkillForUI();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("[action]")]
        [Authorize]
        public IActionResult GetSkillById([FromQuery] Guid id)
        {
            var result = _skillService.GetSkillById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("[action]")]
        [Authorize]
        public IActionResult GetSkillForTable([FromQuery] int page)
        {
            var result = _skillService.GetSkillForTable(page);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("[action]")]
        [Authorize]
        public IActionResult DeleteSkill([FromQuery]Guid id)
        {
            var result = _skillService.DeleteSkill(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPost("[action]")]
        [Authorize]
        public IActionResult AddSkill([FromBody] AddSkillDTO addSkillDTO)
        {
            var result = _skillService.AddSkill(addSkillDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPut("[action]")]
        [Authorize]
        public IActionResult UpdateSkill([FromBody] UpdateSkillDTO updateSkillDTO)
        {
            var result = _skillService.UpdateSkill(updateSkillDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
