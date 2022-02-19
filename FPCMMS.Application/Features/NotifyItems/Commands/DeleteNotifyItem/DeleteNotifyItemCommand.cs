using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPCMMS.Application.Features.NotifyItems.Commands.DeleteNotifyItem
{
    public class DeleteNotifyItemCommand : IRequest
    {
        public int NotifyItemId { get; set; }
    }
}
