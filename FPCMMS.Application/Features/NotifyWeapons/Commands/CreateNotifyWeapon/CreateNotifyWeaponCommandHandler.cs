using AutoMapper;
using FPCMMS.Application.Contracts;
using FPCMMS.Application.Contracts.Persistence;
using FPCMMS.Application.DTOs;
using FPCMMS.Domain.Entities;
using MediatR;

namespace FPCMMS.Application.Features.NotifyWeapons.Commands.CreateNotifyWeapon
{
    public class CreateNotifyWeaponCommandHandler : IRequestHandler<CreateNotifyWeaponCommand, CreateNotifyWeaponCommandResponse>
    {
        private readonly IGenericRepository<NotifyWeapon> _notifyWeaponRepository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public CreateNotifyWeaponCommandHandler(IMapper mapper, IGenericRepository<NotifyWeapon> notifyWeaponRepository, ILoggerManager loggerManager)
        {
            _notifyWeaponRepository = notifyWeaponRepository;
            _mapper = mapper;
            _logger = loggerManager;
        }
        public async Task<CreateNotifyWeaponCommandResponse> Handle(CreateNotifyWeaponCommand request, CancellationToken cancellationToken)
        {
            var createNotifyWeaponCommandResponse = new CreateNotifyWeaponCommandResponse();
            var validator = new CreateNotifyWeaponCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                createNotifyWeaponCommandResponse.Success = false;
                createNotifyWeaponCommandResponse.ValidationErrors = new List<string>();
                _logger.LogError("NotifyWeapon sent from client is not valid.");
                foreach (var error in validationResult.Errors)
                {
                    createNotifyWeaponCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createNotifyWeaponCommandResponse.Success)
            {
                var notifyWeapon = _mapper.Map<NotifyWeapon>(request);
                notifyWeapon = await _notifyWeaponRepository.AddAsync(notifyWeapon);
                createNotifyWeaponCommandResponse.NotifyWeapon = _mapper.Map<NotifyWeaponForCreationDto>(notifyWeapon);

            }

            return createNotifyWeaponCommandResponse;
        }
    }
}
