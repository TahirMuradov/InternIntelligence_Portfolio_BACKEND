using Core.Utilites.Results.Abstract;
using Entities.DTOs.AboutMeDTOs;

namespace DataAccess.Abstract
{
   public interface IAboutMeDAL
    {
        public Task< IResult> AddAboutMeAsync(AddAboutMeDTO addAboutMeDTO);
        public IResult DeleteAboutMe(Guid AboutMeId);
        public Task<IResult> UpdateAboutMeAsync(UpdateAboutMeDTO updateAboutMeDTO);
        public IDataResult<GetAboutMeDetailDTO> GetAboutMeForTable();
        public IDataResult<GetAboutMeForUIDTO> GetAboutMeForUI();
    }
}
