using MediatR;

namespace FPCMMS.Application.Features.NotifyWeapons.Commands.UpdateNotifyWeapon
{
    public class UpdateNotifyWeaponCommand : IRequest
    {
        public Guid Id { get; set; }
        public string WeaponDescription { get; set; }
        public string Attachment { get; set; }
    }
}
