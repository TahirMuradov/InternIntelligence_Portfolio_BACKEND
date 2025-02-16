using Entities.DTOs.MainDTOs;
using FluentValidation;

namespace Bussines.FluentValidations.MainDTOValidations
{
   public class AddMainDTOValidation:AbstractValidator<AddMainDTO>
    {
        public AddMainDTOValidation()
        {

            RuleFor(x => x.Title).NotEmpty().WithMessage("Name cannot be empty")
         .MinimumLength(2).WithMessage("Name must be at least 2 characters")
         .MaximumLength(50).WithMessage("Name must be maximum 50 characters");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description cannot be empty");
            RuleFor(x => x.Description).MinimumLength(2).WithMessage("Description must be at least 2 characters");
            RuleFor(x => x.Description).MaximumLength(100).WithMessage("Description must be maximum 100 characters");
            
        }
    }
}
