using FluentValidation;

namespace FPCMMS.Application.Features.NotifyWeapons.Commands.UpdateNotifyWeapon
{
    public class UpdateNotifyWeaponCommandValidator : AbstractValidator<UpdateNotifyWeaponCommand>
    {
        public UpdateNotifyWeaponCommandValidator()
        {
            RuleFor(p => p.WeaponDescription)
                .NotEmpty().WithMessage("{PropertyWeaponDescription} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyWeaponDescription} must not exceed 50 characters.");

        }
    }
}
