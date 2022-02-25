using AutoMapper;
using FPCMMS.Application.Contracts.Persistence.Weapon;
using FPCMMS.Application.Parameters;
using FPCMMS.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPCMMS.Application.Features.Weapon.NotifyQueries
{
    public class GetAllNotifyQuery : IRequest<PagedResponse<IEnumerable<GetAllNotifyVm>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public class GetAllNotifyWeaponsHandler : IRequestHandler<GetAllNotifyQuery, PagedResponse<IEnumerable<GetAllNotifyVm>>>
        {
            private readonly INotifyRepository _notfiyWeaponrepostory;            
            private readonly IMapper _mapper;
            public GetAllNotifyWeaponsHandler(INotifyRepository notifyWeaponRepository, IMapper mapper)
            {
                _notfiyWeaponrepostory = notifyWeaponRepository;
                _mapper = mapper;
            }
            public async Task<PagedResponse<IEnumerable<GetAllNotifyVm>>> Handle(GetAllNotifyQuery request, CancellationToken cancellationToken)
            {
                var validFilter = _mapper.Map<GetAllNotifyParameter>(request);
                var notifyWeapon = await _notfiyWeaponrepostory.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
                var notifyWeaponViewModel = _mapper.Map<IEnumerable<GetAllNotifyVm>>(notifyWeapon);
                return new PagedResponse<IEnumerable<GetAllNotifyVm>>(notifyWeaponViewModel, validFilter.PageNumber, validFilter.PageSize);
            }
        }
    }
    public class GetAllNotifyParameter : RequestParameter
    {
    }
    public class GetAllNotifyVm
    {
        public int Id { get; set; }
        public string WeaponDescription { get; set; }
        public string? Attachments { get; set; }
    }
}
