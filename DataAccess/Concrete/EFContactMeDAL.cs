using Core.Helpers.EmailHelper.Abstract;
using Core.Helpers.EmailHelper.Concrete;
using Core.Helpers.PageHelper;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete.ErrorResults;
using Core.Utilites.Results.Concrete.SuccessResults;
using DataAccess.Abstract;
using DataAccess.DBContext;
using Entities;
using Entities.DTOs.ContactMeDTOs;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DataAccess.Concrete
{
    public class EFContactMeDAL : IContactMeDAL
    {
        private readonly AppDBContext _dBContext;
        private readonly IEmailHelper _emailHelper;



        public EFContactMeDAL(AppDBContext dBContext, IEmailHelper emailHelper)
        {
            _dBContext = dBContext;
            _emailHelper = emailHelper;
        }

        public IResult AddContactMe(AddContactMeDTO addContactMeDTO)
        {
          CotactMe cotactMe= new CotactMe()
          {
              Email = addContactMeDTO.Email,
              Message = addContactMeDTO.Message,
              Name = addContactMeDTO.Name,
              CreatedDate = DateTime.Now,
              IsRead = false
          };
           
             _dBContext.CotactMes.Add(cotactMe);
            _dBContext.SaveChanges();
            _emailHelper.SendEmailForContactMe(cotactMe.Email,cotactMe.Message,cotactMe.Name,cotactMe.CreatedDate);

            return new SuccessResult(HttpStatusCode.OK);
        }

        public IResult DeleteContactMe(Guid ContactMeId)
        {
            CotactMe cotactMe = _dBContext.CotactMes.FirstOrDefault(x => x.Id == ContactMeId);
            if (cotactMe is null)
                return new ErrorResult("ContactMe not found", HttpStatusCode.NotFound);
            _dBContext.CotactMes.Remove(cotactMe);
            _dBContext.SaveChanges();
            return new SuccessResult(HttpStatusCode.OK);
        }

        public IDataResult<IQueryable<GetContactMeForAlertDTO>> GetContactMeForAlert()
        {
           IQueryable<GetContactMeForAlertDTO> query = _dBContext.CotactMes.AsNoTracking().Select(x => new GetContactMeForAlertDTO()
           {
               Name = x.Name,
               Email = x.Email,
               Message=x.Message,
           });
            return new SuccessDataResult<IQueryable<GetContactMeForAlertDTO>>(query, HttpStatusCode.OK);
        }

        public IDataResult<PaginatedList<GetContactMeForTableDTO>> GetContactMeForTable(int page)
        {
            IQueryable<GetContactMeForTableDTO> query = _dBContext.CotactMes.AsNoTracking().Select(x => new GetContactMeForTableDTO
            {
                Message = x.Message,
                Email = x.Email,
                CreatedDate = x.CreatedDate,
                IsRead = x.IsRead,
                Name = x.Name,
                Id = x.Id
            });
            return new SuccessDataResult<PaginatedList<GetContactMeForTableDTO>>(PaginatedList<GetContactMeForTableDTO>.Create(query, page, 10), HttpStatusCode.OK);
        }

     
    }
}
