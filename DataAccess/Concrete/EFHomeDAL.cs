using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete.SuccessResults;
using DataAccess.Abstract;
using DataAccess.DBContext;
using Entities.DTOs.AboutMeDTOs;
using Entities.DTOs.EducationDTOs;
using Entities.DTOs.HomeDTOs;
using Entities.DTOs.MainDTOs;
using Entities.DTOs.ProjectDTOs;
using Entities.DTOs.SkillDTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class EFHomeDAL : IHomeDAL
    {
        private readonly AppDBContext _context;

        public EFHomeDAL(AppDBContext context)
        {
            _context = context;
        }

        public IDataResult<GetAllDataForHomeDTO> GetAllDataForHome()
        {
            var context = _context;
            GetMainForUIDTO main = context.Mains.AsNoTracking().Select(x => new GetMainForUIDTO
            {
                Description = x.Description,
                Title = x.Title,
            }).FirstOrDefault();
            GetAboutMeForUIDTO getAboutMeForUIDTO = context.AboutMes.AsNoTracking().Select(x => new GetAboutMeForUIDTO
            {
                Adress = x.Adress,
                BirthDay = x.BirthDay,
                CvUrl = x.CvUrl,
                Description = x.Description,
                Email = x.Email,
                FullName = x.FullName,
                Nationality = x.Nationality,
                PhoneNumber = x.PhoneNumber,
                PhotoUrl = x.PhotoUrl,
            }).FirstOrDefault();
       IQueryable<GetEducationForUIDTO> getEducations=context.Educations.AsNoTracking().Select(x => new GetEducationForUIDTO
       {
           Description = x.Description,
           EndDate = x.EndDate,
           StartDate = x.StartDate,
           EducationName= x.EducationName,
           
       });
            IQueryable<GetSkillForUIDTO> getSkills = context.Skills.AsNoTracking().Select(x => new GetSkillForUIDTO
            {
                SkillName = x.Name,
                IsBackend = x.IsBackend,
            });
            IQueryable<GetProjectForUIDTO> getProjects = context.Projects.AsNoTracking().Select(x => new GetProjectForUIDTO
            {
                Description = x.Description,
                Name=x.Name,
                
            });
            GetAllDataForHomeDTO getAllDataForHomeDTO = new GetAllDataForHomeDTO
            {
                AboutMe = getAboutMeForUIDTO,
                Education = getEducations,
                Main = main,
                Project = getProjects,
                Skill = getSkills,
            };
            return new SuccessDataResult<GetAllDataForHomeDTO>(getAllDataForHomeDTO,System.Net.HttpStatusCode.OK);

        }
    }
}
