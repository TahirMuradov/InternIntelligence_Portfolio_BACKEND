using Core.Helpers.PageHelper;
using Core.Utilites.Results.Abstract;
using Entities.DTOs.ProjectDTOs;

namespace DataAccess.Abstract
{
  public  interface IProjectDAL
    {
        public IResult AddProject(AddProjectDTO addProjectDTO);
        public IResult UpdateProject(UpdateProjectDTO updateProjectDTO);
        public IResult DeleteProject(Guid id);
        public IDataResult<IQueryable<GetProjectForUIDTO>> GetProjectForUI();
        public IDataResult<PaginatedList<GetProjectDetailDTO>> GetProjectForTable(int page);
        public IDataResult<GetProjectDetailDTO> GetProjectById(Guid id);
    }
}
