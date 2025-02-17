using Bussines.Abstarct;
using Entities.DTOs.ProjectDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InternIntelligence_Portfolio_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting("Fixed")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpPost("[action]")]
        [Authorize]
        public IActionResult AddProject([FromBody]AddProjectDTO addProjectDTO)
        {
            var result = _projectService.AddProject(addProjectDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("[action]")]
        [Authorize]
        public IActionResult DeleteProject([FromQuery] Guid id)
        {
            var result = _projectService.DeleteProject(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("[action]")]
        [Authorize]
        public IActionResult UpdateProject([FromBody] UpdateProjectDTO updateProjectDTO)
        {
            var result = _projectService.UpdateProject(updateProjectDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("[action]")]
        public IActionResult GetProjectForUI()
        {
            var result = _projectService.GetProjectForUI();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("[action]")]
        [Authorize]
        public IActionResult GetProjectForTable([FromQuery] int page)
        {
            var result = _projectService.GetProjectForTable(page);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("[action]")]
        [Authorize]
        public IActionResult GetProjectById([FromQuery] Guid id)
        {
            var result = _projectService.GetProjectById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

    }
}
