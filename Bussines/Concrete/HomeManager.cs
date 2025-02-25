using Bussines.Abstarct;
using Core.Utilites.Results.Abstract;
using DataAccess.Abstract;
using Entities.DTOs.HomeDTOs;

namespace Bussines.Concrete
{
    public class HomeManager : IHomeService
    {
        private readonly IHomeDAL _homeDAL;

        public HomeManager(IHomeDAL homeDAL)
        {
            _homeDAL = homeDAL;
        }

        public IDataResult<GetAllDataForHomeDTO> GetAllDataForHome()
        {
           return _homeDAL.GetAllDataForHome();
        }
    }
}
