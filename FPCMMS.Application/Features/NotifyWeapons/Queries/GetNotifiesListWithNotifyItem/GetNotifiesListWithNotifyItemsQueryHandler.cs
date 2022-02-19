using AutoMapper;
using FPCMMS.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPCMMS.Application.Features.NotifyWeapons.Queries.GetNotifiesListWithNotifyItem
{
    public class GetNotifiesListWithNotifyItemsQueryHandler : IRequestHandler<GetNotifesListWithNotifyItemsQuery, List<NotifyNotifyItemListVm>>
    {
        private readonly IMapper _mapper;
        private readonly INotifyWeaponRepository _notifyWeaponRepository;
        public GetNotifiesListWithNotifyItemsQueryHandler(INotifyWeaponRepository notifyWeaponRepository, IMapper mapper)
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
