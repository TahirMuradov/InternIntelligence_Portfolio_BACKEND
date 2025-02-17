using Core.Utilites.Results.Abstract;
using Entities.DTOs.MainDTOs;

namespace DataAccess.Abstract
{
   public interface IMainDAL
    {
        public IResult AddMain(AddMainDTO addMainDTO);
        public IResult DeleteMain(Guid MainId);
        public IResult UpdateMain(UpdateMainDTO updateMainDTO);
        
        public IDataResult<GetMainForUIDTO> GetMainForUI();
        public IDataResult<GetMainDetailDTO> GetMainForTable();

    }
}
