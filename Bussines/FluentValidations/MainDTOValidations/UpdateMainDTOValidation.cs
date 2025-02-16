using Entities.DTOs.MainDTOs;
using FluentValidation;

namespace Bussines.FluentValidations.MainDTOValidations
{
  public  class UpdateMainDTOValidation:AbstractValidator<UpdateMainDTO>
    {
        public UpdateMainDTOValidation()
        {
            RuleFor(x => x.Id)
               .NotEmpty().WithMessage("ID cannot be empty.")
               .NotEqual(Guid.Empty).WithMessage("Invalid ID.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title cannot be empty.")
                .MinimumLength(3).WithMessage("Title must be at least 3 characters long.")
                .MaximumLength(100).WithMessage("Title must be at most 100 characters long.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be empty.")
                .MinimumLength(5).WithMessage("Description must be at least 5 characters long.")
                .MaximumLength(500).WithMessage("Description must be at most 500 characters long.");

        }
    }
}
