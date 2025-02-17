using Bussines.Abstarct;
using Bussines.FluentValidations.AboutMeDTOValidations;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete.ErrorResults;
using DataAccess.Abstract;
using Entities.DTOs.AboutMeDTOs;
using System.Net;

namespace Bussines.Concrete
{
    public class AboutMeManager : IAboutMeService
    {
        private readonly IAboutMeDAL _aboutMeDAL;

        public AboutMeManager(IAboutMeDAL aboutMeDAL)
        {
            _aboutMeDAL = aboutMeDAL;
        }

        public async Task<IResult> AddAboutMeAsync(AddAboutMeDTO addAboutMeDTO)
        {
            AddAboutMeDTOValidation addAboutMeDTOValidation = new AddAboutMeDTOValidation();
            var result = await addAboutMeDTOValidation.ValidateAsync(addAboutMeDTO);
            if (!result.IsValid)
                return new ErrorResult(result.Errors.Select(x=>x.ErrorMessage),HttpStatusCode.BadRequest);
            return await _aboutMeDAL.AddAboutMeAsync(addAboutMeDTO);
        }

        public IResult DeleteAboutMe(Guid AboutMeId)
        {
           if (AboutMeId == Guid.Empty)
                return new ErrorResult("Id is not valid", HttpStatusCode.BadRequest);
            return _aboutMeDAL.DeleteAboutMe(AboutMeId);
        }

        public IDataResult<GetAboutMeDetailDTO> GetAboutMeForTable()
        {
            return _aboutMeDAL.GetAboutMeForTable();
        }

        public IDataResult<GetAboutMeForUIDTO> GetAboutMeForUI()
        {
            return _aboutMeDAL.GetAboutMeForUI();
        }

        public async Task<IResult> UpdateAboutMeAsync(UpdateAboutMeDTO updateAboutMeDTO)
        {
            UpdateAboutMeDTOValidation updateAboutMeDTOValidation = new UpdateAboutMeDTOValidation();
            var result = await updateAboutMeDTOValidation.ValidateAsync(updateAboutMeDTO);
            if (!result.IsValid)
                return new ErrorResult(result.Errors.Select(x => x.ErrorMessage), HttpStatusCode.BadRequest);
            return await _aboutMeDAL.UpdateAboutMeAsync(updateAboutMeDTO);
        }
    }
}
