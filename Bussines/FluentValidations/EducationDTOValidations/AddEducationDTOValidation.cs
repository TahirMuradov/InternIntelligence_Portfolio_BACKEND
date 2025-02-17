using Entities.DTOs.EducationDTOs;
using FluentValidation;

namespace Bussines.FluentValidations.EducationDTOValidations
{
    public class AddEducationDTOValidation:AbstractValidator<AddEducationDTO>
    {
        public AddEducationDTOValidation()
        {
            RuleFor(x => x.EducationName)
               .NotEmpty().WithMessage("Education name cannot be empty.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start date is required.");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("End date is required.")
                .GreaterThan(x => x.StartDate).WithMessage("End date must be greater than start date.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be empty.");
        }
    }
}
