using AutoMapper;
using FPCMMS.Application.Contracts.Generic;
using FPCMMS.Application.Contracts.Persistence;
using FPCMMS.Application.DTOs;
using FPCMMS.Application.DTOs.Notify;
using FPCMMS.Application.Exceptions;
using FPCMMS.Domain.Entities;
using MediatR;

namespace FPCMMS.Application.Features.NotifyItems.Queries.GetNotifyDetail
{
    public class GetNotifyDetailQueryHandler : IRequestHandler<GetNotifyDetailQuery, NotifyDetailVm>
    {
        private readonly IGenericRepository<Notify> _notifyRepository;
        private readonly IGenericRepository<NotifyItem> _notifyIetmRepository;
        private readonly IMapper _mapper;
        public GetNotifyDetailQueryHandler(IMapper mapper, IGenericRepository<Notify> notifyRepository, IGenericRepository<NotifyItem> notifyIetmRepository)
        {
            _notifyIetmRepository = notifyIetmRepository;
            _mapper = mapper;
            _notifyRepository = notifyRepository;
        }
        public async Task<NotifyDetailVm> Handle(GetNotifyDetailQuery request, CancellationToken cancellationToken)
        {
            var notifyItem = await _notifyIetmRepository.GetByIdAsync(request.NotifyItemId);
            var notifyDetailDto = _mapper.Map<NotifyDetailVm>(notifyItem);

            var notify = await _notifyRepository.GetByIdAsync(notifyItem.NotifyId);

            if (notify == null)
            {
                throw new NotFoundException(nameof(NotifyItem), request.NotifyItemId);
            }
            notifyDetailDto.Notify = _mapper.Map<NotifyWeaponDto>(notify);

            return notifyDetailDto;
        }
    }
}
