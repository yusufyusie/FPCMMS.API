using FluentValidation;

namespace FPCMMS.Application.Features.NotifyWeapons.Commands.CreateNotifyWeapon
{
    public class CreateNotifyWeaponCommandValidator : AbstractValidator<CreateNotifyWeaponCommand>
    {
        public CreateNotifyWeaponCommandValidator()
        {
            RuleFor(p => p.WeaponDescription)
               .NotEmpty().WithMessage("{PropertyDescription} is required.")
               .NotNull()
               .MaximumLength(10).WithMessage("{PropertyDescription} must not exceed 10 characters.");

        }
    }
}
