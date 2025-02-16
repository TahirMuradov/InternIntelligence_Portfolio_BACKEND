using Bussines.Abstarct;
using Entities.DTOs.AboutMeDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.Tasks;

namespace InternIntelligence_Portfolio_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting("Fixed")]
    [Authorize]
    public class AboutmeController : ControllerBase
    {
        private readonly IAboutMeService _aboutMeService;

        public AboutmeController(IAboutMeService aboutMeService)
        {
            _aboutMeService = aboutMeService;
        }
        [HttpDelete("[action]")]
        public IActionResult DeleteAboutMe([FromQuery] Guid AboutMeId)
        {
            var result = _aboutMeService.DeleteAboutMe(AboutMeId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddAboutMe([FromForm] AddAboutMeDTO addAboutMeDTO)
        {
            var result = await _aboutMeService.AddAboutMeAsync(addAboutMeDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAboutMe([FromForm] UpdateAboutMeDTO updateAboutMeDTO)
        {
            var result = await _aboutMeService.UpdateAboutMeAsync(updateAboutMeDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("[action]")]
        public IActionResult GetAboutMeForUI()
        {
            var result = _aboutMeService.GetAboutMeForUI();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("[action]")]
        public IActionResult GetAboutMeForTable()
        {
            var result = _aboutMeService.GetAboutMeForTable();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

    }
}
