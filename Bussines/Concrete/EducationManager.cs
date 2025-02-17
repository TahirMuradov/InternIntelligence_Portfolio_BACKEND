using Bussines.Abstarct;
using Bussines.FluentValidations.EducationDTOValidations;
using Core.Helpers.PageHelper;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete.ErrorResults;
using DataAccess.Abstract;
using Entities.DTOs.EducationDTOs;
using System.Net;

namespace Bussines.Concrete
{
    public class EducationManager : IEducationService
    {
        private readonly IEducationDAL _educationDAL;

        public EducationManager(IEducationDAL educationDAL)
        {
            _educationDAL = educationDAL;
        }

        public IResult AddEducatioon(AddEducationDTO addEducationDTO)
        {
        AddEducationDTOValidation validationRules = new AddEducationDTOValidation();
            var result = validationRules.Validate(addEducationDTO);
            if (!result.IsValid)
                return new ErrorResult(result.Errors.Select(x=>x.ErrorMessage),HttpStatusCode.BadRequest);
            return _educationDAL.AddEducatioon(addEducationDTO);
        }

        public IResult DeleteEducation(Guid id)
        {
           if (id == Guid.Empty)
                return new ErrorResult("Id cannot be empty", HttpStatusCode.BadRequest);
            return _educationDAL.DeleteEducation(id);
        }

        public IDataResult<GetEducationDetailDTO> GetEducationById(Guid id)
        {
            if (id == Guid.Empty)
                return new ErrorDataResult<GetEducationDetailDTO>("Id cannot be empty", HttpStatusCode.BadRequest);
            return _educationDAL.GetEducationById(id);
        }

        public IDataResult<PaginatedList<GetEducationDetailDTO>> GetEducationForTable(int page)
        {
          if(page<1)
                page = 1;
            return _educationDAL.GetEducationForTable(page);
        }

        public IDataResult<IQueryable<GetEducationForUIDTO>> GetEducationForUI()
        {
            return _educationDAL.GetEducationForUI();
        }

        public IResult UpdateEducation(UpdateEducationDTO updateEducationDTO)
        {
           UpdateEducationDTOValidation validationRules = new UpdateEducationDTOValidation();
            var result = validationRules.Validate(updateEducationDTO);
            if (!result.IsValid)
                return new ErrorResult(result.Errors.Select(x => x.ErrorMessage), HttpStatusCode.BadRequest);
            return _educationDAL.UpdateEducation(updateEducationDTO);
        }
    }
}
