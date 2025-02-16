using Core.Utilites.Results.Abstract;
using Entities.DTOs.AboutMeDTOs;

namespace Bussines.Abstarct
{
    public interface IAboutMeService
    {
        public Task<IResult> AddAboutMeAsync(AddAboutMeDTO addAboutMeDTO);
        public IResult DeleteAboutMe(Guid AboutMeId);
        public Task<IResult> UpdateAboutMeAsync(UpdateAboutMeDTO updateAboutMeDTO);
        public IDataResult<GetAboutMeForTableDTO> GetAboutMeForTable();
        public IDataResult<GetAboutMeForUIDTO> GetAboutMeForUI();

    }
}
