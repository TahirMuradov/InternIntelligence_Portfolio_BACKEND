using Entities.DTOs.AboutMeDTOs;
using FluentValidation;

namespace Bussines.FluentValidations.AboutMeDTOValidations
{
    public class UpdateAboutMeDTOValidation : AbstractValidator<UpdateAboutMeDTO>
    {
        public UpdateAboutMeDTOValidation()
        {
            RuleFor(x => x.Id)
               .NotEmpty().WithMessage("ID cannot be empty.")
               .NotEqual(Guid.Empty).WithMessage("Invalid ID.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be empty.");

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Full name cannot be empty.");

            RuleFor(x => x.BirthDay)
                .NotEmpty().WithMessage("Birth date cannot be empty.")
                .GreaterThan(DateTime.Today).WithMessage("Birth date must be after today.");

            RuleFor(x => x.Nationality)
                .NotEmpty().WithMessage("Nationality cannot be empty.");

            RuleFor(x => x.Adress)
                .NotEmpty().WithMessage("Address cannot be empty.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number cannot be empty.")
                .Matches(@"^(?:\+994-?(?:\d{2}-?\d{3}-?\d{2}-?\d{2}|\d{2}-?\d{3}-?\d{2}-?\d{2})|(\d{3}-?\d{3}-?\d{2}-?\d{2}|\d{3}-?\d{3}-?\d{2}-?\d{2}-?))$")
                .WithMessage("Invalid phone number format.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Invalid email format.");


        }
    }
}

