using Entities.DTOs.AboutMeDTOs;
using Entities.DTOs.EducationDTOs;
using Entities.DTOs.MainDTOs;
using Entities.DTOs.ProjectDTOs;
using Entities.DTOs.SkillDTOs;

namespace Entities.DTOs.HomeDTOs
{
  public  class GetAllDataForHomeDTO
    {
        public GetMainForUIDTO Main { get; set; }
        public GetAboutMeForUIDTO AboutMe { get; set; }
        public IQueryable< GetEducationForUIDTO> Education { get; set; }
     
        public IQueryable<GetSkillForUIDTO> Skill { get; set; }
        public IQueryable<GetProjectForUIDTO> Project { get; set; }
     
    }
}
