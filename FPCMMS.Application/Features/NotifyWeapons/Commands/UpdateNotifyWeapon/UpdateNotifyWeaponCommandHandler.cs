using AutoMapper;
using FPCMMS.Application.Contracts.Persistence;
using FPCMMS.Application.Exceptions;
using FPCMMS.Domain.Entities;
using MediatR;

namespace FPCMMS.Application.Features.NotifyWeapons.Commands.UpdateNotifyWeapon
{
    public class UpdateNotifyWeaponCommandHandler : IRequestHandler<UpdateNotifyWeaponCommand>
    {
        private readonly IGenericRepository<NotifyWeapon> _notifyWeaponRepository;
        //private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public UpdateNotifyWeaponCommandHandler(IGenericRepository<NotifyWeapon> genericRepository, IMapper mapper)
        {
            _notifyWeaponRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateNotifyWeaponCommand request, CancellationToken cancellationToken)
        {
            var notifyWeaponToUpdate = await _notifyWeaponRepository.GetByIdAsync(request.Id);
            if (notifyWeaponToUpdate == null)
            {
                throw new ApiException(nameof(NotifyWeapon), request.Id);
            }
            var validator = new UpdateNotifyWeaponCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)

                throw new ValidationException(validationResult);
            _mapper.Map(request, notifyWeaponToUpdate, typeof(UpdateNotifyWeaponCommand), typeof(NotifyWeapon));
            await _notifyWeaponRepository.UpdateAsync(notifyWeaponToUpdate);
            return Unit.Value;

        }
    }
}
