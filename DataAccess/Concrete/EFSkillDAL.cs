using Core.Helpers.PageHelper;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete.ErrorResults;
using Core.Utilites.Results.Concrete.SuccessResults;
using DataAccess.Abstract;
using DataAccess.DBContext;
using Entities;
using Entities.DTOs.SkillDTOs;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DataAccess.Concrete
{
    public class EFSkillDAL : ISkillDAL
    {
        private readonly AppDBContext _dBContext;

        public EFSkillDAL(AppDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public IResult AddSkill(AddSkillDTO addSkillDTO)
        {
            Skill skill = new Skill() {
                Name = addSkillDTO.SkillName,
                IsBackend = addSkillDTO.IsBackend,
            };
            _dBContext.Skills.Add(skill);
            _dBContext.SaveChanges();
            return new SuccessResult(HttpStatusCode.OK);
        }

        public IResult DeleteSkill(Guid id)
        {
           Skill skill = _dBContext.Skills.FirstOrDefault(x=>x.Id==id);
            if (skill is null)
                return new ErrorResult("Skill not found", HttpStatusCode.NotFound);
            _dBContext.Skills.Remove(skill);
            _dBContext.SaveChanges();
            return new SuccessResult(HttpStatusCode.OK);
        }

        public IDataResult<GetSkillDetailDTO> GetSkillById(Guid id)
        {
           GetSkillDetailDTO getSkill=_dBContext.Skills.AsNoTracking().Select(x => new GetSkillDetailDTO()
           {
               Id = x.Id,
               SkillName = x.Name,
               IsBackend = x.IsBackend,
           }).FirstOrDefault(x => x.Id == id);
            if (getSkill is null)
                return new ErrorDataResult<GetSkillDetailDTO>("Skill not found", HttpStatusCode.NotFound);
            return new SuccessDataResult<GetSkillDetailDTO>(getSkill, HttpStatusCode.OK);
        }

        public IDataResult<PaginatedList<GetSkillDetailDTO>> GetSkillForTable(int page)
        {
            IQueryable<GetSkillDetailDTO> query = _dBContext.Skills.AsNoTracking().Select(x => new GetSkillDetailDTO()
            {
                Id = x.Id,
                SkillName = x.Name,
                IsBackend = x.IsBackend,
            });
            return new SuccessDataResult<PaginatedList<GetSkillDetailDTO>>(PaginatedList<GetSkillDetailDTO>.Create(query, page,10), HttpStatusCode.OK);
        }

        public IDataResult<IQueryable<GetSkillForUIDTO>> GetSkillForUI()
        {
            return new SuccessDataResult<IQueryable<GetSkillForUIDTO>>(_dBContext.Skills.AsNoTracking().Select(x => new GetSkillForUIDTO()
            {
                SkillName = x.Name,
                IsBackend = x.IsBackend,
            }), HttpStatusCode.OK);
        }

        public IResult UpdateSkill(UpdateSkillDTO updateSkillDTO)
        {
            Skill skill=_dBContext.Skills.FirstOrDefault(x => x.Id == updateSkillDTO.Id);
            if (skill is null)
                return new ErrorResult("Skill not found", HttpStatusCode.NotFound);
            skill.Name = updateSkillDTO.SkillName;
            skill.IsBackend = updateSkillDTO.IsBackend;
            _dBContext.Update(skill);
            _dBContext.SaveChanges();
            return new SuccessResult(HttpStatusCode.OK);
        }
    }
}
