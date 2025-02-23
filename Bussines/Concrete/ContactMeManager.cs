using Bussines.Abstarct;
using Bussines.FluentValidations.ContactMeDTOValidations;
using Core.Helpers.PageHelper;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete.ErrorResults;
using DataAccess.Abstract;
using Entities.DTOs.ContactMeDTOs;
using System.Net;

namespace Bussines.Concrete
{
    public class ContactMeManager : IContactMeService
    {
        private readonly IContactMeDAL _contactDAL;

        public ContactMeManager(IContactMeDAL contactDAL)
        {
            _contactDAL = contactDAL;
        }

        public IResult AddContactMe(AddContactMeDTO addContactMeDTO)
        {
            AddContactMeDTOValidation validationRules = new AddContactMeDTOValidation();
            var result = validationRules.Validate(addContactMeDTO);
            if (!result.IsValid)
                return new ErrorResult(result.Errors.Select(x => x.ErrorMessage),HttpStatusCode.BadRequest);
            return _contactDAL.AddContactMe(addContactMeDTO);
        }

        public IResult ChangeStatus(Guid id)
        {
            if (id == Guid.Empty)
                return new ErrorResult("Id cannot be empty", HttpStatusCode.BadRequest);
            return _contactDAL.ChangeStatus(id);
        }

        public IResult DeleteContactMe(Guid ContactMeId)
        {
            if (ContactMeId == Guid.Empty)
                return new ErrorResult("Id cannot be empty", HttpStatusCode.BadRequest);
            return _contactDAL.DeleteContactMe(ContactMeId);
        }

        public IDataResult<IQueryable<GetContactMeForAlertDTO>> GetContactMeForAlert()
        {
            return _contactDAL.GetContactMeForAlert();
        }

        public IDataResult<PaginatedList<GetContactMeForTableDTO>> GetContactMeForTable(int page)
        {
            if (page < 1)
                page = 1;
            return _contactDAL.GetContactMeForTable(page);
        }

        public IDataResult<int> GetCountNewContactMe()
        {
            return _contactDAL.GetCountNewContactMe();
        }
    }

 
}
