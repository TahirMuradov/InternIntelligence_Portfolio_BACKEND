using Core.Utilites.Results.Abstract;
using Entities.DTOs.HomeDTOs;

namespace Bussines.Abstarct
{
  public  interface IHomeService
    {
        public IDataResult<GetAllDataForHomeDTO> GetAllDataForHome();
    }
}
