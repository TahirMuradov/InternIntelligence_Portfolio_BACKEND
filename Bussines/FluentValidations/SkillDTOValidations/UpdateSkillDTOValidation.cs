using Entities.DTOs.SkillDTOs;
using FluentValidation;

namespace Bussines.FluentValidations.SkillDTOValidations
{
  public  class UpdateSkillDTOValidation:AbstractValidator<UpdateSkillDTO>
    {
        public UpdateSkillDTOValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id cannot be empty.");
            RuleFor(x => x.SkillName)
                .NotEmpty().WithMessage("Skill name cannot be empty.");
        }
    }
}
