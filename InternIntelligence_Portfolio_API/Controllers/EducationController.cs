using Bussines.Abstarct;
using Entities.DTOs.EducationDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InternIntelligence_Portfolio_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting("Fixed")]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        [HttpGet("[action]")]
        [Authorize]
        public IActionResult GetEducationForTable([FromQuery]int page)
        {
            var result = _educationService.GetEducationForTable(page);
          
                return result.IsSuccess? Ok(result):BadRequest(result);
          
        }
        [HttpGet("[action]")]
        [Authorize]
        public IActionResult GetEducationById([FromQuery]Guid id)
        {
            var result = _educationService.GetEducationById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("[action]")]
        public IActionResult GetEducationForUI()
        {
            var result = _educationService.GetEducationForUI();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("[action]")]
        [Authorize]
        public IActionResult DeleteEducation([FromQuery] Guid id)
        {
            var result = _educationService.DeleteEducation(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPost("[action]")]
        [Authorize]
        public IActionResult AddEducation([FromBody]AddEducationDTO addEducationDTO)
        {
            var result = _educationService.AddEducatioon(addEducationDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPut("[action]")]
        [Authorize]
        public IActionResult UpdateEducation([FromBody]UpdateEducationDTO updateEducationDTO)
        {
            var result = _educationService.UpdateEducation(updateEducationDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
