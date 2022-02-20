

using FPCMMS.Application.DTOs;
using FPCMMS.Application.DTOs.Notify;
using FPCMMS.Application.Responses;

namespace FPCMMS.Application.Features.NotifyWeapons.Commands.CreateNotifyWeapon
{
    public class CreateNotifyWeaponCommandResponse : BaseResponse<int>
    {
        public CreateNotifyWeaponCommandResponse() : base()
        {

        }
        public NotifyWeaponForCreationDto Notify { get; set; }

    }
}
