using MediatR;

namespace FPCMMS.Application.Features.NotifyWeapons.Commands.UpdateNotifyWeapon
{
    public class UpdateNotifyWeaponCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string Attachment { get; set; }
    }
}
