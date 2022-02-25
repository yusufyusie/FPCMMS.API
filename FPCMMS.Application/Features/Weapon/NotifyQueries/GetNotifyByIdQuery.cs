using FPCMMS.Application.Contracts.Persistence.Weapon;
using FPCMMS.Application.Exceptions;
using FPCMMS.Application.Responses;
using FPCMMS.Domain.Entities;
using MediatR;

namespace FPCMMS.Application.Features.Weapon.NotifyQueries
{
    public class GetNotifyByIdQuery : IRequest<BaseResponse<Notify>>
    {
        public int Id { get; set; }
        public class GetNotifyWeaponByIdQueryHandler : IRequestHandler<GetNotifyByIdQuery, BaseResponse<Notify>>
        {
            private readonly INotifyRepository _notifyWeaponRepository;
            public GetNotifyWeaponByIdQueryHandler(INotifyRepository notifyWeaponRepository)
            {
                _notifyWeaponRepository = notifyWeaponRepository;
            }

            public async Task<BaseResponse<Notify>> Handle(GetNotifyByIdQuery request, CancellationToken cancellationToken)
            {
                var notifyWeapon = await _notifyWeaponRepository.GetByIdAsync(request.Id);
                if (notifyWeapon == null)

                    throw new ApiException($"notifyWeapon Not Found.");
                return new BaseResponse<Notify>(notifyWeapon);

            }
        }
    }

}
