using Entities.DTOs.ProjectDTOs;
using FluentValidation;

namespace Bussines.FluentValidations.ProjectDTOValidations
{
    class UpdateProjectDTOValidation:AbstractValidator<UpdateProjectDTO>
    {
        public UpdateProjectDTOValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id cannot be empty.");
            RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Name cannot be empty.")
           .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be empty.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
        }
    }
}
