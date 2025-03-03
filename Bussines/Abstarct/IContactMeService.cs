﻿using Core.Helpers.PageHelper;
using Core.Utilites.Results.Abstract;
using Entities.DTOs.ContactMeDTOs;

namespace Bussines.Abstarct
{
  public  interface IContactMeService
    {
        public IResult AddContactMe(AddContactMeDTO addContactMeDTO);
        public IResult DeleteContactMe(Guid ContactMeId);
        public IResult ChangeStatus(Guid id);
        public IDataResult<int> GetCountNewContactMe();
        public IDataResult<PaginatedList<GetContactMeForTableDTO>> GetContactMeForTable(int page);

        public IDataResult<IQueryable<GetContactMeForAlertDTO>> GetContactMeForAlert();
    }
}
