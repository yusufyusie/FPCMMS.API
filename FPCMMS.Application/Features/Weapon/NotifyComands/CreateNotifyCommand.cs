using AutoMapper;
using FluentValidation;
using FPCMMS.Application.Contracts.Generic;
using FPCMMS.Application.Contracts.Service;
using FPCMMS.Application.DTOs.Notify;
using FPCMMS.Application.DTOs.NotifyItem;
using FPCMMS.Application.Responses;
using FPCMMS.Domain.Entities;
using MediatR;

namespace FPCMMS.Application.Features.Weapon.NotifyComands
{
    public class CreateNotifyCommand : IRequest<CreateNotifyCommandResponse>
    {
        public string WeaponDescription { get; set; }
        public string? Attachments { get; set; }
       public IEnumerable<NotifyItemForCreationDto> NotifyItems { get; set; }
    }

    public class CreateNotifyCommandResponse : BaseResponse<int>
    {
        public CreateNotifyCommandResponse() : base()
        {

        }
        public NotifyForCreationDto Notify { get; set; }

    }

    public class CreateNotifyCommandValidator : AbstractValidator<CreateNotifyCommand>
    {
        public CreateNotifyCommandValidator()
        {
            RuleFor(p => p.WeaponDescription)
              .NotEmpty().WithMessage("{PropertyDescription} is required.")
              .NotNull()
              .MaximumLength(10).WithMessage("{PropertyDescription} must not exceed 10 characters.");
        }
    }

    public class CreateNotifyCommandHandler : IRequestHandler<CreateNotifyCommand, CreateNotifyCommandResponse>
    {
        private readonly IGenericRepository<Notify> _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public CreateNotifyCommandHandler(IGenericRepository<Notify> repository, IMapper mapper, ILoggerManager loggerManager)
        {
            _repository = repository;
            _logger = loggerManager;
            _mapper = mapper;
        }
        public async Task<CreateNotifyCommandResponse> Handle(CreateNotifyCommand request, CancellationToken cancellationToken)
        {
            var createNotifyCommandResponse = new CreateNotifyCommandResponse();
            var validator = new CreateNotifyCommandValidator();
            var validationresult = await validator.ValidateAsync(request, cancellationToken);
            if (validationresult.Errors.Count > 0)
            {
                createNotifyCommandResponse.Success = false;
                createNotifyCommandResponse.ValidationErrors = new List<string>();
                _logger.LogError("NotifyWeapon sent from client is not valid.");
                foreach (var error in validationresult.Errors)
                {
                    createNotifyCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createNotifyCommandResponse.Success)
            {
                var notify = _mapper.Map<Notify>(request);
                notify = await _repository.AddAsync(notify);
                createNotifyCommandResponse.Notify = _mapper.Map<NotifyForCreationDto>(notify);
            }
            return createNotifyCommandResponse;
        }
    }
}
