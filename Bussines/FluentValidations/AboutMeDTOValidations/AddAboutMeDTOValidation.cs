using Entities.DTOs.AboutMeDTOs;
using FluentValidation;

namespace Bussines.FluentValidations.AboutMeDTOValidations
{
    public class AddAboutMeDTOValidation : AbstractValidator<AddAboutMeDTO>
    {

        public AddAboutMeDTOValidation()
        {
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

            RuleFor(x => x.Photo)
                   .NotNull().WithMessage("Photo is required.")
                   .Must(file => file != null && (
                       file.ContentType.Equals("image/jpeg") ||
                       file.ContentType.Equals("image/png")))
                   .WithMessage("Only .jpg, .jpeg, and .png files are allowed for the photo.");

            RuleFor(x => x.Cv)
                .NotNull().WithMessage("CV is required.")
                .Must(file => file != null && file.ContentType.Equals("application/pdf"))
                .WithMessage("Only .pdf files are allowed for the CV.");
        }
    }
}
