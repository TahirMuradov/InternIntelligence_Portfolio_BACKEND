using Core.Helpers.PageHelper;
using Core.Utilites.Results.Abstract;
using Entities.DTOs.SkillDTOs;

namespace Bussines.Abstarct
{
   public interface ISkillService
    {
        public IResult AddSkill(AddSkillDTO addSkillDTO);
        public IResult UpdateSkill(UpdateSkillDTO updateSkillDTO);
        public IResult DeleteSkill(Guid id);
        public IDataResult<IQueryable<GetSkillForUIDTO>> GetSkillForUI();
        public IDataResult<PaginatedList<GetSkillDetailDTO>> GetSkillForTable(int page);
        public IDataResult<GetSkillDetailDTO> GetSkillById(Guid id);
    }
}
