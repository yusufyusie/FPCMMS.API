using AutoMapper;
using FPCMMS.Application.Contracts.Persistence.Weapon;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPCMMS.Application.Features.Weapon.NotifyQueries
{
    public class GetNotifesListWithNotifyItemsQuery : IRequest<List<NotifyNotifyItemListVm>>
    {
        public bool IncludeHistory { get; set; }
        public class GetNotifiesListWithNotifyItemsQueryHandler : IRequestHandler<GetNotifesListWithNotifyItemsQuery, List<NotifyNotifyItemListVm>>
        {
            private readonly IMapper _mapper;
            private readonly INotifyRepository _notifyWeaponRepository;
            public GetNotifiesListWithNotifyItemsQueryHandler(INotifyRepository notifyWeaponRepository, IMapper mapper)
            {
                _notifyWeaponRepository = notifyWeaponRepository;
                _mapper = mapper;
            }

            public async Task<List<NotifyNotifyItemListVm>> Handle(GetNotifesListWithNotifyItemsQuery request, CancellationToken cancellationToken)
            {
                var list = await _notifyWeaponRepository.GetNotifiesWithNotifyItems(request.IncludeHistory);
                return _mapper.Map<List<NotifyNotifyItemListVm>>(list);
            }
        }
    }
    public class NotifyNotifyItemDto
    {
        public int Id { get; set; }
        public string WeaponName { get; set; }
        public string WeaponType { get; set; }
        public int Quantity { get; set; }
        public int NotifiesId { get; set; }
    }
    public class NotifyNotifyItemListVm
    {
        public int Id { get; set; }
        public string WeaponDescription { get; set; }
        public string? Attachments { get; set; }
        public ICollection<NotifyNotifyItemDto> NotifyItems { get; set; }
    }
}
