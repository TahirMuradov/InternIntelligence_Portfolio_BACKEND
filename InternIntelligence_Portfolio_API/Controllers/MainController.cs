using Bussines.Abstarct;
using Entities.DTOs.MainDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InternIntelligence_Portfolio_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting("Fixed")]
    
    public class MainController : ControllerBase
    {
        private readonly IMainService _mainService;

        public MainController(IMainService mainService)
        {
            _mainService = mainService;
        }
        [HttpPost("[action]")]
        [Authorize]
        public IActionResult AddMain([FromBody] AddMainDTO addMainDTO)
        {
            var result=_mainService.AddMain(addMainDTO);    
            return result.IsSuccess?Ok(result):BadRequest(result);
        }
        [HttpDelete("[action]")]
        [Authorize]
        public IActionResult DeleteMain([FromQuery]Guid MainId)
        {
            var result = _mainService.DeleteMain(MainId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);

        }
        [HttpPut("[action]")]
        [Authorize]
        public IActionResult UpdateMain([FromBody] UpdateMainDTO updateMainDTO)
        {
            var result=_mainService.UpdateMain(updateMainDTO);  
            return  result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    
        [HttpGet("[action]")]
       
        public IActionResult GetMainForUI()
        {
            
            var result = _mainService.GetMainForUI();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("[action]")]
        [Authorize]
        public IActionResult GetMainForTable()
        {

            var result = _mainService.GetMainForTable();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
