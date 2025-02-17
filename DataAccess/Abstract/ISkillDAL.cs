using Core.Helpers.PageHelper;
using Core.Utilites.Results.Abstract;
using Entities.DTOs.SkillDTOs;

namespace DataAccess.Abstract
{
   public interface ISkillDAL
    {
        public IResult AddSkill(AddSkillDTO addSkillDTO);
        public IResult UpdateSkill(UpdateSkillDTO updateSkillDTO);
        public IResult DeleteSkill(Guid id);
        public IDataResult<IQueryable<GetSkillForUIDTO>> GetSkillForUI();
        public IDataResult<PaginatedList<GetSkillDetailDTO>> GetSkillForTable(int page);
        public IDataResult<GetSkillDetailDTO> GetSkillById(Guid id);
    }
}
