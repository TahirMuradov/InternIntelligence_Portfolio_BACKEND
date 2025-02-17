using Core.Helpers;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete.ErrorResults;
using Core.Utilites.Results.Concrete.SuccessResults;
using DataAccess.Abstract;
using DataAccess.DBContext;
using Entities;
using Entities.DTOs.AboutMeDTOs;
using Microsoft.EntityFrameworkCore;
using System.Net;


namespace DataAccess.Concrete
{
    public class EFAboutDAL : IAboutMeDAL
    {
        private readonly AppDBContext _dBContext;

        public EFAboutDAL(AppDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<IResult> AddAboutMeAsync(AddAboutMeDTO addAboutMeDTO)
        {
            string photoUrl = await FileHelper.SaveFileAsync(addAboutMeDTO.Photo);
            string cvUrl = await FileHelper.SaveFileAsync(addAboutMeDTO.Cv);

            AboutMe aboutMe = new AboutMe()
            {
                Adress = addAboutMeDTO.Adress,
                BirthDay = addAboutMeDTO.BirthDay,
                Description = addAboutMeDTO.Description,
                Email = addAboutMeDTO.Email,
                FullName = addAboutMeDTO.FullName,
                Nationality=addAboutMeDTO.Nationality,
                PhoneNumber = addAboutMeDTO.PhoneNumber,
                PhotoUrl= photoUrl,
                CvUrl = cvUrl
            };
           await _dBContext.AboutMes.AddAsync(aboutMe);
            await _dBContext.SaveChangesAsync();
            return new SuccessResult(HttpStatusCode.OK);

        }

        public IResult DeleteAboutMe(Guid AboutMeId)
        {
            AboutMe aboutMe = _dBContext.AboutMes.FirstOrDefault(x=>x.Id==AboutMeId);
            if (aboutMe is null)
                return new ErrorResult("AboutMe not found", HttpStatusCode.NotFound);
            FileHelper.RemoveFile(aboutMe.PhotoUrl);
            FileHelper.RemoveFile(aboutMe.CvUrl);
            _dBContext.AboutMes.Remove(aboutMe);
            _dBContext.SaveChanges();
            return new SuccessResult(HttpStatusCode.OK);
        }

        public IDataResult<GetAboutMeDetailDTO> GetAboutMeForTable()
        {
            GetAboutMeDetailDTO aboutme = _dBContext.AboutMes.AsNoTracking().Select(x => new GetAboutMeDetailDTO
            {
                Id = x.Id,
                Adress = x.Adress,
                CvUrl = x.CvUrl,
                BirthDay = x.BirthDay,
                Description = x.Description,
                Email = x.Email,
                FullName = x.FullName,
                Nationality = x.Nationality,
                PhoneNumber = x.PhoneNumber,
                PhotoUrl = x.PhotoUrl,

            }).FirstOrDefault();
            return new SuccessDataResult<GetAboutMeDetailDTO>(aboutme, HttpStatusCode.OK);
        }

        public IDataResult<GetAboutMeForUIDTO> GetAboutMeForUI()
        {
            GetAboutMeForUIDTO aboutme = _dBContext.AboutMes.AsNoTracking().Select(x => new GetAboutMeForUIDTO
            {
                
                Adress = x.Adress,
                CvUrl = x.CvUrl,
                BirthDay = x.BirthDay,
                Description = x.Description,
                Email = x.Email,
                FullName = x.FullName,
                Nationality = x.Nationality,
                PhoneNumber = x.PhoneNumber,
                PhotoUrl = x.PhotoUrl,

            }).FirstOrDefault();
            return new SuccessDataResult<GetAboutMeForUIDTO>(aboutme, HttpStatusCode.OK);
        }

        public async Task<IResult> UpdateAboutMeAsync(UpdateAboutMeDTO updateAboutMeDTO)
        {
            AboutMe aboutMe = _dBContext.AboutMes.FirstOrDefault(x => x.Id == updateAboutMeDTO.Id);
            if (aboutMe is null)
                return new ErrorResult("Aboutme not found", HttpStatusCode.NotFound);
                aboutMe.Adress = updateAboutMeDTO.Adress;
            aboutMe.BirthDay = updateAboutMeDTO.BirthDay;
            aboutMe.Description = updateAboutMeDTO.Description;
            aboutMe.Email = updateAboutMeDTO.Email;
            aboutMe.FullName = updateAboutMeDTO.FullName;
            aboutMe.PhoneNumber = updateAboutMeDTO.PhoneNumber;
            if (updateAboutMeDTO.Cv is not null)
            {
                FileHelper.RemoveFile(aboutMe.CvUrl);
                string cvUrl = await FileHelper.SaveFileAsync(updateAboutMeDTO.Cv);
                aboutMe.CvUrl = cvUrl;
            }
            if (updateAboutMeDTO.Photo is not null)
            {
                FileHelper.RemoveFile(aboutMe.PhotoUrl);
                string photoUrl = await FileHelper.SaveFileAsync(updateAboutMeDTO.Photo);
                aboutMe.PhotoUrl = photoUrl;
            }

            _dBContext.AboutMes.Update(aboutMe);
            await _dBContext.SaveChangesAsync();
            return new SuccessResult(HttpStatusCode.OK);
        }
    }
}
