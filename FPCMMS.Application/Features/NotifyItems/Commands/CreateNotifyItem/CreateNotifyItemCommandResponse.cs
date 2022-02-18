using FPCMMS.Application.DTOs;
using FPCMMS.Application.Responses;

namespace FPCMMS.Application.Features.NotifyItems.Commands.CreateNotifyItem
{
    public class CreateNotifyItemCommandResponse : BaseResponse<int>
    {
        public CreateNotifyItemCommandResponse() : base()
        {

        }
        public NotifyItemForCreationDto NotifyItem { get; set; }
    
    }
}
