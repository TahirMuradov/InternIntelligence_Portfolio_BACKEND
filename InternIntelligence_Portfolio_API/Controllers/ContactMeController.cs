using Bussines.Abstarct;
using Entities.DTOs.ContactMeDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InternIntelligence_Portfolio_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting("Fixed")]
    public class ContactMeController : ControllerBase
    {
        private readonly IContactMeService _contactMeService;

        public ContactMeController(IContactMeService contactMeService)
        {
            _contactMeService = contactMeService;
        }
        [HttpGet("[action]")]
        [Authorize]
        public IActionResult GetContactMeForTable([FromQuery] int page)
        {
            var result = _contactMeService.GetContactMeForTable(page);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("[action]")]
        [Authorize]
        public IActionResult GetContactMeForAlert()
        {
            var result = _contactMeService.GetContactMeForAlert();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPut("[action]")]
        [Authorize]
        public IActionResult ChangeStatusContactMe([FromQuery] Guid Id)
        {
            var result = _contactMeService.ChangeStatus(Id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("[action]")]
        [Authorize]
        public IActionResult DeleteContactMe([FromQuery] Guid id)
        {
            var result = _contactMeService.DeleteContactMe(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("[action]")]
        [Authorize]
        public IActionResult GetCountNewContactMe()
        {
            var result = _contactMeService.GetCountNewContactMe();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPost("[action]")]
        public IActionResult AddContactMe([FromBody] AddContactMeDTO addContactMeDTO)
        {
            var result = _contactMeService.AddContactMe(addContactMeDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
