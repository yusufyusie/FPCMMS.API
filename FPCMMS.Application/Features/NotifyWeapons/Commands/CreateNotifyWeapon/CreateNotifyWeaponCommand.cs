using FPCMMS.Application.DTOs;
using FPCMMS.Application.DTOs.NotifyItem;
using MediatR;

namespace FPCMMS.Application.Features.NotifyWeapons.Commands.CreateNotifyWeapon
{
    public class CreateNotifyWeaponCommand : IRequest<CreateNotifyWeaponCommandResponse>
    {       
        public string WeaponDescription { get; set; }
        public string Attachments { get; set; }
        public IEnumerable<NotifyItemForCreationDto> NotifyItems { get; set; }
    }
}

