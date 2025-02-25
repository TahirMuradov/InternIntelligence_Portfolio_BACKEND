using Core.Utilites.Results.Abstract;
using Entities.DTOs.HomeDTOs;

namespace DataAccess.Abstract
{
   public interface IHomeDAL
    {
        public IDataResult<GetAllDataForHomeDTO> GetAllDataForHome();
    }
}
