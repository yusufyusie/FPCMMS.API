using FPCMMS.Application.Contracts.Persistence;
using FPCMMS.Application.Exceptions;
using FPCMMS.Application.Responses;
using FPCMMS.Domain.Entities;
using MediatR;

namespace FPCMMS.Application.Features.NotifyWeapons.Queries.GetNotifyWeaponById
{
    public class GetNotifyWeaponsByIdQuery : IRequest<BaseResponse<NotifyWeapon>>
    {
        public Guid Id { get; set; }
        public class GetNotifyWeaponByIdQueryHandler : IRequestHandler<GetNotifyWeaponsByIdQuery, BaseResponse<NotifyWeapon>>
        {
            private readonly INotifyWeaponRepository _notifyWeaponRepository;
            public GetNotifyWeaponByIdQueryHandler(INotifyWeaponRepository notifyWeaponRepository)
            {
                _notifyWeaponRepository = notifyWeaponRepository;
            }

            public async Task<BaseResponse<NotifyWeapon>> Handle(GetNotifyWeaponsByIdQuery request, CancellationToken cancellationToken)
            {
                var notifyWeapon = await _notifyWeaponRepository.GetByIdAsync(request.Id);
                if (notifyWeapon == null)

                    throw new ApiException($"notifyWeapon Not Found.");
                return new BaseResponse<NotifyWeapon>(notifyWeapon);

            }
        }
    }
}
