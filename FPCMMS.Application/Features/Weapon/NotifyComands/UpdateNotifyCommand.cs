using AutoMapper;
using FluentValidation;
using FPCMMS.Application.Contracts.Generic;
using FPCMMS.Application.Exceptions;
using FPCMMS.Domain.Entities;
using MediatR;
using ValidationException = FPCMMS.Application.Exceptions.ValidationException;

namespace FPCMMS.Application.Features.Weapon.NotifyComands
{
    public class UpdateNotifyCommand : IRequest
    {
        public int Id { get; set; }
        public string WeaponDescription { get; set; }
        public string? Attachments { get; set; }
    }
    public class UpdateNotifyWeaponCommandValidator : AbstractValidator<UpdateNotifyCommand>
    {
        public UpdateNotifyWeaponCommandValidator()
        {
            RuleFor(p => p.WeaponDescription)
                .NotEmpty().WithMessage("{PropertyWeaponDescription} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyWeaponDescription} must not exceed 50 characters.");

        }
    }
    public class UpdateNotifyWeaponCommandHandler : IRequestHandler<UpdateNotifyCommand>
    {
        private readonly IGenericRepository<Notify> _notifyWeaponRepository;
        private readonly IMapper _mapper;
        public UpdateNotifyWeaponCommandHandler(IGenericRepository<Notify> genericRepository, IMapper mapper)
        {
            _notifyWeaponRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateNotifyCommand request, CancellationToken cancellationToken)
        {
            var notifyWeaponToUpdate = await _notifyWeaponRepository.GetByIdAsync(request.Id);
            if (notifyWeaponToUpdate == null)
            {
                throw new ApiException(nameof(Notify), request.Id);
            }
            var validator = new UpdateNotifyWeaponCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)

                throw new ValidationException(validationResult);
            _mapper.Map(request, notifyWeaponToUpdate, typeof(UpdateNotifyCommand), typeof(Notify));
            await _notifyWeaponRepository.UpdateAsync(notifyWeaponToUpdate);
            return Unit.Value;

        }
    }
}
