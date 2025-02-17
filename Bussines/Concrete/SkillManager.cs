using Bussines.Abstarct;
using Bussines.FluentValidations.SkillDTOValidations;
using Core.Helpers.PageHelper;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete.ErrorResults;
using DataAccess.Abstract;
using Entities.DTOs.SkillDTOs;
using System.Net;

namespace Bussines.Concrete
{
    public class SkillManager : ISkillService
    {
        private readonly ISkillDAL _skillDAL;

        public SkillManager(ISkillDAL skillDAL)
        {
            _skillDAL = skillDAL;
        }

        public IResult AddSkill(AddSkillDTO addSkillDTO)
        {
           AddSkillDTOValidation validationRules = new AddSkillDTOValidation();
            var result = validationRules.Validate(addSkillDTO);
            if (!result.IsValid)
                return new ErrorResult(result.Errors.Select(x => x.ErrorMessage),HttpStatusCode.BadRequest);
            return _skillDAL.AddSkill(addSkillDTO);
        }

        public IResult DeleteSkill(Guid id)
        {
            if (id == Guid.Empty)
                return new ErrorResult("Id cannot be empty", HttpStatusCode.BadRequest);
            return _skillDAL.DeleteSkill(id);
        }

        public IDataResult<GetSkillDetailDTO> GetSkillById(Guid id)
        {
            if (id == Guid.Empty)
                return new ErrorDataResult<GetSkillDetailDTO>("Id cannot be empty", HttpStatusCode.BadRequest);
            return _skillDAL.GetSkillById(id);
        }

        public IDataResult<PaginatedList<GetSkillDetailDTO>> GetSkillForTable(int page)
        {
            if (page < 1)
                page = 1;
            return _skillDAL.GetSkillForTable(page);
        }

        public IDataResult<IQueryable<GetSkillForUIDTO>> GetSkillForUI()
        {
          return _skillDAL.GetSkillForUI();
        }

        public IResult UpdateSkill(UpdateSkillDTO updateSkillDTO)
        {
          UpdateSkillDTOValidation validationRules = new UpdateSkillDTOValidation();
            var result = validationRules.Validate(updateSkillDTO);
            if (!result.IsValid)
                return new ErrorResult(result.Errors.Select(x => x.ErrorMessage), HttpStatusCode.BadRequest);
            return _skillDAL.UpdateSkill(updateSkillDTO);
        }
    }
}
