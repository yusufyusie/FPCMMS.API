using AutoMapper;
using FPCMMS.Application.Contracts.Generic;
using FPCMMS.Application.DTOs.Notify;
using FPCMMS.Application.Exceptions;
using FPCMMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPCMMS.Application.Features.Weapon.NotifyDetailQueries
{
    public class GetNotifyDetailQuery : IRequest<NotifyDetailVm>
    {
        public int Id { get; set; }
    }
    public class NotifyDetailVm
    {
        public int Id { get; set; }
        public string WeaponName { get; set; }
        public string WeaponType { get; set; }
        public int Quantity { get; set; }
        public int NotifiesId { get; set; }
        public NotifyWeaponDto Notify { get; set; }
    }
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
            var notifyItem = await _notifyIetmRepository.GetByIdAsync(request.Id);
            var notifyDetailDto = _mapper.Map<NotifyDetailVm>(notifyItem);

            var notify = await _notifyRepository.GetByIdAsync(notifyItem.Id);

            if (notify == null)
            {
                throw new NotFoundException(nameof(NotifyItem), request.Id);
            }
            notifyDetailDto.Notify = _mapper.Map<NotifyWeaponDto>(notify);

            return notifyDetailDto;
        }
    }
}
