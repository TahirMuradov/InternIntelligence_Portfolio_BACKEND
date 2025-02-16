using Core.Helpers.PageHelper;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete.ErrorResults;
using Core.Utilites.Results.Concrete.SuccessResults;
using DataAccess.Abstract;
using DataAccess.DBContext;
using Entities;
using Entities.DTOs.MainDTOs;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DataAccess.Concrete
{
    public class EFMainDAL : IMainDAL
    {
        private readonly AppDBContext _dBContext;

        public EFMainDAL(AppDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public IResult AddMain(AddMainDTO addMainDTO)
        {
           _dBContext.Mains.RemoveRange(_dBContext.Mains);
            Main main = new Main()
            {
                Title = addMainDTO.Title,
                Description = addMainDTO.Description,
            };
            _dBContext.Mains.Add(main);
            _dBContext.SaveChanges();
            return new SuccessResult(HttpStatusCode.OK);
        }

        public IResult DeleteMain(Guid MainId)
        {
          Main checkedMain=_dBContext.Mains.FirstOrDefault(x=>x.Id==MainId);
            if (checkedMain is null)
              return new ErrorResult("Main not found", HttpStatusCode.NotFound);
           
            _dBContext.Mains.Remove(checkedMain);
            _dBContext.SaveChanges();
            return new SuccessResult(HttpStatusCode.OK);
        }

        public IDataResult<GetMainForUIDTO> GetMainForUI()
        {
            GetMainForUIDTO getMain = _dBContext.Mains.AsNoTracking().Select(x => new GetMainForUIDTO
            {
             
                Title = x.Title,
                Description = x.Description,
            }).FirstOrDefault();
           
            return new SuccessDataResult<GetMainForUIDTO>(getMain,HttpStatusCode.OK);
        }

  
        public IResult UpdateMain(UpdateMainDTO updateMainDTO)
        {
            Main main=_dBContext.Mains.FirstOrDefault(x=>x.Id == updateMainDTO.Id);
            if (main is null)
                return new ErrorResult("Main not found ", HttpStatusCode.NotFound);
            main.Title = updateMainDTO.Title;
            main.Description= updateMainDTO.Description;
            _dBContext.Mains.Update(main);
            _dBContext.SaveChanges();
            return new SuccessResult(HttpStatusCode.OK);


        }

        public IDataResult<GetMainDTO> GetMainForTable()
        {

            GetMainDTO getMain = _dBContext.Mains.AsNoTracking().Select(x => new GetMainDTO
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
            }).FirstOrDefault();
            
            return new SuccessDataResult<GetMainDTO>(data: getMain, HttpStatusCode.OK);

        }
    }
}
