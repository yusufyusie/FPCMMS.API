using FluentValidation;

namespace FPCMMS.Application.Features.NotifyWeapons.Commands.CreateNotifyWeapon
{
    public class CreateNotifyWeaponCommandValidator : AbstractValidator<CreateNotifyWeaponCommand>
    {
        public CreateNotifyWeaponCommandValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 10 characters.");

        }
    }
}
