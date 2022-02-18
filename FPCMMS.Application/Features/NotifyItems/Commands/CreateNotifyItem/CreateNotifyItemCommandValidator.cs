using FluentValidation;

namespace FPCMMS.Application.Features.NotifyItems.Commands.CreateNotifyItem
{
    public class CreateNotifyItemCommandValidator :AbstractValidator<CreateNotifyItemCommand>
    {
        public CreateNotifyItemCommandValidator()
        {
            RuleFor(p => p.WeaponName)
               .NotEmpty().WithMessage("{PropertyDescription} is required.")
               .NotNull()
               .MaximumLength(10).WithMessage("{PropertyDescription} must not exceed 10 characters.");
        }
    }
}
