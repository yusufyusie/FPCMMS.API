using MediatR;

namespace FPCMMS.Application.Features.NotifyWeapons.Commands.DeleteNotifyWeapon
{
    public class DeleteNotifyWeaponCommand : IRequest
    {
        public int Id { get; set; }
    }
}
