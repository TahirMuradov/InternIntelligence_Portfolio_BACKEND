using Entities.DTOs.ContactMeDTOs;
using FluentValidation;

namespace Bussines.FluentValidations.ContactMeDTOValidations
{
   public class AddContactMeDTOValidation:AbstractValidator<AddContactMeDTO>
    {
        public AddContactMeDTOValidation()
        {
            RuleFor(x => x.Name)
              .NotEmpty().WithMessage("Name cannot be empty.")
              .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Message cannot be empty.")
                .MinimumLength(10).WithMessage("Message must be at least 10 characters long.")
                .MaximumLength(1000).WithMessage("Message cannot exceed 1000 characters.");
        }
    }
}
