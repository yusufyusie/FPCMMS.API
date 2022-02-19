using AutoMapper;
using FPCMMS.Application.Contracts.Persistence;
using FPCMMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPCMMS.Application.Features.NotifyItems.Queries.GetNotifyList
{
    public class GetNotifyListQueryHandler : IRequestHandler<GetNotifyListQuery, List<NotifyListVm>>
    {
        private readonly IGenericRepository<NotifyItem> _notifyIetmRepository;
        private readonly IMapper _mapper;
        public GetNotifyListQueryHandler(IMapper mapper, IGenericRepository<NotifyItem> notifyIetmRepository)
        {
            _notifyIetmRepository = notifyIetmRepository;
            _mapper = mapper;
        }

        public async Task<List<NotifyListVm>> Handle(GetNotifyListQuery request, CancellationToken cancellationToken)
        {
            var allNotifies = (await _notifyIetmRepository.GetAllAsync()).OrderBy(x => x.WeaponName);
            return _mapper.Map<List<NotifyListVm>>(allNotifies);
        }
    }
}
