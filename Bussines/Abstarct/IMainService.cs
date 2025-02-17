using Core.Utilites.Results.Abstract;
using Entities.DTOs.MainDTOs;

namespace Bussines.Abstarct
{
   public interface IMainService
    {
        public IResult AddMain(AddMainDTO addMainDTO);
        public IResult DeleteMain(Guid MainId);
        public IResult UpdateMain(UpdateMainDTO updateMainDTO);

        public IDataResult<GetMainForUIDTO> GetMainForUI();
        public IDataResult<GetMainDetailDTO> GetMainForTable();
    }
}
