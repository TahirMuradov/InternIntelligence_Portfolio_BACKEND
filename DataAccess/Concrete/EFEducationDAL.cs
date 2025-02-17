using Core.Helpers.PageHelper;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete.ErrorResults;
using Core.Utilites.Results.Concrete.SuccessResults;
using DataAccess.Abstract;
using DataAccess.DBContext;
using Entities;
using Entities.DTOs.EducationDTOs;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DataAccess.Concrete
{
    public class EFEducationDAL : IEducationDAL
    {
        private readonly AppDBContext _dBContext;

        public EFEducationDAL(AppDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public IResult AddEducatioon(AddEducationDTO addEducationDTO)
        {
         Education education = new Education()
         {
             Description = addEducationDTO.Description,
             EducationName = addEducationDTO.EducationName,
             EndDate = addEducationDTO.EndDate,
             StartDate = addEducationDTO.StartDate
         };
            _dBContext.Educations.Add(education);
            _dBContext.SaveChanges();
            return new SuccessResult(HttpStatusCode.OK);
        }

        public IResult DeleteEducation(Guid id)
        {
            Education education = _dBContext.Educations.FirstOrDefault(x=>x.Id==id);
            if (education is null)
                return new ErrorResult("Education not found", HttpStatusCode.NotFound);
            _dBContext.Educations.Remove(education);
            _dBContext.SaveChanges();
            return new SuccessResult(HttpStatusCode.OK);
        }

        public IDataResult<GetEducationDetailDTO> GetEducationById(Guid id)
        {
            GetEducationDetailDTO getEducation=_dBContext.Educations.AsNoTracking().Select(x => new GetEducationDetailDTO()
            {
                Id=x.Id,
                Description = x.Description,
                EducationName = x.EducationName,
                EndDate = x.EndDate,
                StartDate = x.StartDate
            }).FirstOrDefault(x => x.Id == id);
            if (getEducation is null)
                return new ErrorDataResult<GetEducationDetailDTO>("Education not found", HttpStatusCode.NotFound);
            return new SuccessDataResult<GetEducationDetailDTO>(getEducation, HttpStatusCode.OK);
        }

        public IDataResult<PaginatedList<GetEducationDetailDTO>> GetEducationForTable(int page)
        {
          IQueryable<  GetEducationDetailDTO> query = _dBContext.Educations.AsNoTracking().Select(x => new GetEducationDetailDTO()
            {
                Id = x.Id,
                Description = x.Description,
                EducationName = x.EducationName,
                EndDate = x.EndDate,
                StartDate = x.StartDate
            });
            var paginatedList = PaginatedList<GetEducationDetailDTO>.Create(query, page, 10);
            return new SuccessDataResult<PaginatedList<GetEducationDetailDTO>>(paginatedList, HttpStatusCode.OK);
        }

        public IDataResult<IQueryable<GetEducationForUIDTO>> GetEducationForUI()
        {
           return new SuccessDataResult<IQueryable<GetEducationForUIDTO>>(_dBContext.Educations.AsNoTracking().Select(x => new GetEducationForUIDTO()
           {
               Description = x.Description,
               EducationName = x.EducationName,
               EndDate = x.EndDate,
               StartDate = x.StartDate
           }), HttpStatusCode.OK);
        }

        public IResult UpdateEducation(UpdateEducationDTO updateEducationDTO)
        {
          Education education=_dBContext.Educations.FirstOrDefault(x => x.Id == updateEducationDTO.Id);
            if (education is null)
                return new ErrorResult("Education not found", HttpStatusCode.NotFound);
            education.Description = updateEducationDTO.Description;
            education.EducationName = updateEducationDTO.EducationName;
            education.EndDate = updateEducationDTO.EndDate;
            education.StartDate = updateEducationDTO.StartDate;
            _dBContext.SaveChanges();
            return new SuccessResult(HttpStatusCode.OK);
        }
    }
}
