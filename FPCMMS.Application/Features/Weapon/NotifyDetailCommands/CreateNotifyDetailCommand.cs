using AutoMapper;
using FluentValidation;
using FPCMMS.Application.Contracts.Generic;
using FPCMMS.Application.Contracts.Service;
using FPCMMS.Application.DTOs.NotifyItem;
using FPCMMS.Application.Responses;
using FPCMMS.Domain.Entities;
using MediatR;

namespace FPCMMS.Application.Features.Weapon.NotifyDetailCommands
{
    public class CreateNotifyDetailCommand : IRequest<CreateNotifyDetailCommandResponse>
    {
        public string WeaponName { get; set; }
        public string WeaponType { get; set; }
        public int Quantity { get; set; }
        public int NotifyId { get; set; }
    }
    public class CreateNotifyDetailCommandResponse : BaseResponse<int>
    {
        public CreateNotifyDetailCommandResponse() : base()
        {

        }
        public NotifyItemForCreationDto NotifyItem { get; set; }

    }
    public class CreateNotifyDetailCommandValidator : AbstractValidator<CreateNotifyDetailCommand>
    {
        public CreateNotifyDetailCommandValidator()
        {
            RuleFor(p => p.WeaponName)
               .NotEmpty().WithMessage("{PropertyDescription} is required.")
               .NotNull()
               .MaximumLength(10).WithMessage("{PropertyDescription} must not exceed 10 characters.");
        }
    }
    public class CreateNotifyItemCommandHandler : IRequestHandler<CreateNotifyDetailCommand, CreateNotifyDetailCommandResponse>
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

        public async Task<CreateNotifyDetailCommandResponse> Handle(CreateNotifyDetailCommand request, CancellationToken cancellationToken)
        {
            var createNotifyItemCommandResponse = new CreateNotifyDetailCommandResponse();
            var validator = new CreateNotifyDetailCommandValidator();
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

