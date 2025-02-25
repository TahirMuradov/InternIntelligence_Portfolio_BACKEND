using Bussines.Abstarct;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InternIntelligence_Portfolio_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting("Fixed")]
    public class HomeController : ControllerBase
    {
        private readonly IHomeService _homeService;
        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }
        [HttpGet("[action]")]
        public IActionResult GetAllDataForHome()
        {
            var result = _homeService.GetAllDataForHome();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
