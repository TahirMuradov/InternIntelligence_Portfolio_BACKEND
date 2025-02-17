using Core.Helpers.PageHelper;
using Core.Utilites.Results.Abstract;
using Entities.DTOs.ContactMeDTOs;

namespace DataAccess.Abstract
{
    public interface IContactMeDAL
    {
        public IResult AddContactMe(AddContactMeDTO addContactMeDTO);
        public IResult DeleteContactMe(Guid ContactMeId);

        public IDataResult<PaginatedList<GetContactMeForTableDTO>> GetContactMeForTable(int page);

        public IDataResult<IQueryable<GetContactMeForAlertDTO>> GetContactMeForAlert();
    }
}
