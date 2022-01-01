using AutoMapper;
using FPCMMS.Application.Contracts.Persistence;
using FPCMMS.Application.Exceptions;
using FPCMMS.Domain.Entities;
using MediatR;

namespace FPCMMS.Application.Features.NotifyWeapons.Commands.DeleteNotifyWeapon
{
    public class DeleteNotifyWeaponCommandHandler : IRequestHandler<DeleteNotifyWeaponCommand>
    {
        private readonly IGenericRepository<NotifyWeapon> _notifyWeaponRepository;
        //private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public DeleteNotifyWeaponCommandHandler(IGenericRepository<NotifyWeapon> genericRepository, IMapper mapper)
        {
            _notifyWeaponRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteNotifyWeaponCommand request, CancellationToken cancellationToken)
        {
            var notifyWeaponToDelete = await _notifyWeaponRepository.GetByIdAsync(request.Id);
            if (notifyWeaponToDelete == null)
            {
                throw new ApiException(nameof(NotifyWeapon), request.Id);
            }
            await _notifyWeaponRepository.DeleteAsync(notifyWeaponToDelete);
            return Unit.Value;

        }
    }
}
