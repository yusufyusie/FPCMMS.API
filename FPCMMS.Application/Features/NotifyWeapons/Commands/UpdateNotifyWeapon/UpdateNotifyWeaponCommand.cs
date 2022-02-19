using MediatR;

namespace FPCMMS.Application.Features.NotifyWeapons.Commands.UpdateNotifyWeapon
{
    public class UpdateNotifyWeaponCommand : IRequest
    {
        public int Id { get; set; }
        public string WeaponDescription { get; set; }
        public string Attachment { get; set; }
    }
}
