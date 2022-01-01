using AutoMapper;
using FPCMMS.Application.Contracts.Persistence;
using FPCMMS.Application.Responses;
using MediatR;

namespace FPCMMS.Application.Features.NotifyWeapons.Queries.GetAllNotifyWeapons
{
    public class GetAllNotifyWeaponsQuery : IRequest<PagedResponse<IEnumerable<GetAllNotifyWeaponsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public class GetAllNotifyWeaponsHandler : IRequestHandler<GetAllNotifyWeaponsQuery, PagedResponse<IEnumerable<GetAllNotifyWeaponsViewModel>>>
        {
            private readonly INotifyWeaponRepository _notfiyWeaponrepostory;
            //private readonly ILoggerManager _logger;
            private readonly IMapper _mapper;
            public GetAllNotifyWeaponsHandler(INotifyWeaponRepository notifyWeaponRepository, IMapper mapper)
            {
                _notfiyWeaponrepostory = notifyWeaponRepository;
                _mapper = mapper;
            }
            public async Task<PagedResponse<IEnumerable<GetAllNotifyWeaponsViewModel>>> Handle(GetAllNotifyWeaponsQuery request, CancellationToken cancellationToken)
            {
                var validFilter = _mapper.Map<GetAllNotifyWeaponsParameter>(request);
                var notifyWeapon = await _notfiyWeaponrepostory.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
                var notifyWeaponViewModel = _mapper.Map<IEnumerable<GetAllNotifyWeaponsViewModel>>(notifyWeapon);
                return new PagedResponse<IEnumerable<GetAllNotifyWeaponsViewModel>>(notifyWeaponViewModel, validFilter.PageNumber, validFilter.PageSize);
            }
        }
    }
}
