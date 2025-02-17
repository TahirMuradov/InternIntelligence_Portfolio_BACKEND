using Core.Helpers.PageHelper;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete.ErrorResults;
using Core.Utilites.Results.Concrete.SuccessResults;
using DataAccess.Abstract;
using DataAccess.DBContext;
using Entities;
using Entities.DTOs.ProjectDTOs;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DataAccess.Concrete
{

    public class EFProjectDAL : IProjectDAL
    {
        private readonly AppDBContext _dBContext;

        public EFProjectDAL(AppDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public IResult AddProject(AddProjectDTO addProjectDTO)
        {
        Project project = new Project
        {
            Name = addProjectDTO.Name,
            Description = addProjectDTO.Description
        };
            _dBContext.Projects.Add(project);
            _dBContext.SaveChanges();
            return new SuccessResult(HttpStatusCode.OK);
        }

        public IResult DeleteProject(Guid id)
        {
            Project project = _dBContext.Projects.FirstOrDefault(x=>x.Id==id);
            if (project is null)
                return new ErrorResult("Project not found", HttpStatusCode.NotFound);
            _dBContext.Projects.Remove(project);
            _dBContext.SaveChanges();
            return new SuccessResult(HttpStatusCode.OK);
        }

        public IDataResult<GetProjectDetailDTO> GetProjectById(Guid id)
        {
            GetProjectDetailDTO project = _dBContext.Projects.AsNoTracking().Select(x => new GetProjectDetailDTO()
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name
            }).FirstOrDefault(x => x.Id == id);
          
                return project is null? new ErrorDataResult<GetProjectDetailDTO>("Project not found", HttpStatusCode.NotFound):
                new SuccessDataResult<GetProjectDetailDTO>(project, HttpStatusCode.OK);
        }

        public IDataResult<PaginatedList<GetProjectDetailDTO>> GetProjectForTable(int page)
        {
           IQueryable<GetProjectDetailDTO> getProjectDetailDTOs = _dBContext.Projects.AsNoTracking().Select(x => new GetProjectDetailDTO()
           {
               Id = x.Id,
               Description = x.Description,
               Name = x.Name
           });
            return new SuccessDataResult<PaginatedList<GetProjectDetailDTO>>(PaginatedList<GetProjectDetailDTO>.Create(getProjectDetailDTOs, page, 10), HttpStatusCode.OK);
        }

        public IDataResult<IQueryable<GetProjectForUIDTO>> GetProjectForUI()
        {
            IQueryable<GetProjectForUIDTO> getProjectDetailDTOs = _dBContext.Projects.AsNoTracking().Select(x => new GetProjectForUIDTO()
            {
               
                Description = x.Description,
                Name = x.Name
            });
            return new SuccessDataResult<IQueryable<GetProjectForUIDTO>>(getProjectDetailDTOs, HttpStatusCode.OK);
        }

        public IResult UpdateProject(UpdateProjectDTO updateProjectDTO)
        {
          Project project = _dBContext.Projects.FirstOrDefault(x => x.Id == updateProjectDTO.Id);
            if (project is null)
                return new ErrorResult("Project not found", HttpStatusCode.NotFound);
            project.Name = updateProjectDTO.Name;
            project.Description = updateProjectDTO.Description;
            _dBContext.Projects.Update(project);
            _dBContext.SaveChanges();
            return new SuccessResult(HttpStatusCode.OK);
        }
    }
}
