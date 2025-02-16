using Bussines.Abstarct;
using Bussines.FluentValidations.MainDTOValidations;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete.ErrorResults;
using DataAccess.Abstract;
using Entities.DTOs.MainDTOs;
using System.Net;

namespace Bussines.Concrete
{
    public class MainManager : IMainService
    {
        private readonly IMainDAL _mainDAL;

        public MainManager(IMainDAL mainDAL)
        {
            _mainDAL = mainDAL;
        }

        public IResult AddMain(AddMainDTO addMainDTO)
        {
          AddMainDTOValidation validationRules = new AddMainDTOValidation();
            var validationResult = validationRules.Validate(addMainDTO);
            if (!validationResult.IsValid)
                return new ErrorResult(validationResult.Errors.Select(x => x.ErrorMessage), HttpStatusCode.OK);
            return _mainDAL.AddMain(addMainDTO);
        }

        public IResult DeleteMain(Guid MainId)
        {
            if (MainId == default) return new ErrorResult(HttpStatusCode.BadRequest);
            return _mainDAL.DeleteMain(MainId);
           
        }

        public IDataResult<GetMainForUIDTO> GetMainForUI()
        {
           
            return _mainDAL.GetMainForUI();
        }

       

        public IResult UpdateMain(UpdateMainDTO updateMainDTO)
        {
            UpdateMainDTOValidation validationRules=new UpdateMainDTOValidation();
            var validationResult = validationRules.Validate(updateMainDTO);
            if (!validationResult.IsValid)
                return new ErrorResult(validationResult.Errors.Select(x => x.ErrorMessage), HttpStatusCode.BadRequest);
            return _mainDAL.UpdateMain(updateMainDTO);

        }

        public IDataResult<GetMainDTO> GetMainForTable()
        {
            return _mainDAL.GetMainForTable();
        }
    }
}
