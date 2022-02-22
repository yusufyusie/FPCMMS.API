using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPCMMS.Application.Features.NotifyItems.Commands.CreateNotifyItem
{
   public class CreateNotifyItemCommand : IRequest<CreateNotifyItemCommandResponse>
    {
        public string WeaponName { get; set; }
        public string WeaponType { get; set; }
        public int Quantity { get; set; }
        public int NotifiesId { get; set; }
    }
}
