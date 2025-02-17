using Bussines.Abstarct;
using Bussines.FluentValidations.AboutMeDTOValidations;
using Bussines.FluentValidations.ProjectDTOValidations;
using Core.Helpers.PageHelper;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete.ErrorResults;
using DataAccess.Abstract;
using Entities.DTOs.ProjectDTOs;
using System.Net;

namespace Bussines.Concrete
{
    public class ProjectManager : IProjectService
    {
        private readonly IProjectDAL _projectDAL;

        public ProjectManager(IProjectDAL projectDAL)
        {
            _projectDAL = projectDAL;
        }

        public IResult AddProject(AddProjectDTO addProjectDTO)
        {
            AddProjectDTOValidation validationRules = new AddProjectDTOValidation();
            var result = validationRules.Validate(addProjectDTO);
            if (!result.IsValid)
                return new ErrorResult(result.Errors.Select(x => x.ErrorMessage),HttpStatusCode.BadRequest);
            return _projectDAL.AddProject(addProjectDTO);
        }

        public IResult DeleteProject(Guid id)
        {
            if (id == Guid.Empty)
                return new ErrorResult("Id cannot be empty", HttpStatusCode.BadRequest);
            return _projectDAL.DeleteProject(id);
        }

        public IDataResult<GetProjectDetailDTO> GetProjectById(Guid id)
        {
            if (id == Guid.Empty)
                return new ErrorDataResult<GetProjectDetailDTO>("Id cannot be empty", HttpStatusCode.BadRequest);
            return _projectDAL.GetProjectById(id);
        }

        public IDataResult<PaginatedList<GetProjectDetailDTO>> GetProjectForTable(int page)
        {
           if (page < 1)
                page = 1;
            return _projectDAL.GetProjectForTable(page);
        }

        public IDataResult<IQueryable<GetProjectForUIDTO>> GetProjectForUI()
        {
            return _projectDAL.GetProjectForUI();
        }

        public IResult UpdateProject(UpdateProjectDTO updateProjectDTO)
        {
            UpdateProjectDTOValidation validationRules = new UpdateProjectDTOValidation();
            var result = validationRules.Validate(updateProjectDTO);
            if (!result.IsValid)
                return new ErrorResult(result.Errors.Select(x => x.ErrorMessage), HttpStatusCode.BadRequest);
            return _projectDAL.UpdateProject(updateProjectDTO);
        }
    }
}
