using Entities.DTOs.ProjectDTOs;
using FluentValidation;

namespace Bussines.FluentValidations.ProjectDTOValidations
{
   public class AddProjectDTOValidation: AbstractValidator<AddProjectDTO>
    {
        public AddProjectDTOValidation()
        {
            RuleFor(x => x.Name)
             .NotEmpty().WithMessage("Name cannot be empty.")
             .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be empty.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
        }
    }
}
