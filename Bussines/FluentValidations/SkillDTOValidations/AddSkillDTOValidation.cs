using Entities.DTOs.SkillDTOs;
using FluentValidation;

namespace Bussines.FluentValidations.SkillDTOValidations
{
   public class AddSkillDTOValidation:AbstractValidator<AddSkillDTO>
    {
        public AddSkillDTOValidation()
        {
            RuleFor(x => x.SkillName)
               .NotEmpty().WithMessage("Skill name cannot be empty.");

        }
    }
}
