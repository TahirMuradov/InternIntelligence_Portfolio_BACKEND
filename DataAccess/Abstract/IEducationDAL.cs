using Core.Helpers.PageHelper;
using Core.Utilites.Results.Abstract;
using Entities.DTOs.EducationDTOs;

namespace DataAccess.Abstract
{
    public interface IEducationDAL
    {
        public IResult AddEducatioon(AddEducationDTO addEducationDTO);
        public IResult UpdateEducation(UpdateEducationDTO updateEducationDTO);
        public IResult DeleteEducation(Guid id);
        public IDataResult<IQueryable<GetEducationForUIDTO>> GetEducationForUI();
        public IDataResult<PaginatedList<GetEducationDetailDTO>> GetEducationForTable(int page);
        public IDataResult<GetEducationDetailDTO> GetEducationById(Guid id);
    }
}
