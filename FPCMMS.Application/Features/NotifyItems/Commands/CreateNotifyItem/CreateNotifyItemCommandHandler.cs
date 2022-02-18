using AutoMapper;
using FPCMMS.Application.Contracts;
using FPCMMS.Application.Contracts.Persistence;
using FPCMMS.Application.DTOs;
using FPCMMS.Domain.Entities;
using MediatR;

namespace FPCMMS.Application.Features.NotifyItems.Commands.CreateNotifyItem
{
    public class CreateNotifyItemCommandHandler : IRequestHandler<CreateNotifyItemCommand, CreateNotifyItemCommandResponse>
    {
        private readonly IGenericRepository<NotifyItem> _notifyItemRepository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public CreateNotifyItemCommandHandler(IMapper mapper, IGenericRepository<NotifyItem> notifyWeaponRepository, ILoggerManager loggerManager)
        {
            _notifyItemRepository = notifyWeaponRepository; 
            _logger = loggerManager;
            _mapper = mapper;
        }

        public async Task<CreateNotifyItemCommandResponse> Handle(CreateNotifyItemCommand request, CancellationToken cancellationToken)
        {
            var createNotifyItemCommandResponse = new CreateNotifyItemCommandResponse();
            var validator = new CreateNotifyItemCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                createNotifyItemCommandResponse.Success = false;
                createNotifyItemCommandResponse.ValidationErrors = new List<string>();
                _logger.LogError("NotifyItem sent from client is not valid.");
                foreach (var error in validationResult.Errors)
                {
                    createNotifyItemCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createNotifyItemCommandResponse.Success)
            {
                var notifyItem = _mapper.Map<NotifyItem>(request);
                notifyItem = await _notifyItemRepository.AddAsync(notifyItem);
                createNotifyItemCommandResponse.NotifyItem = _mapper.Map<NotifyItemForCreationDto>(notifyItem);

            }
            return createNotifyItemCommandResponse;
        }
    }
}
