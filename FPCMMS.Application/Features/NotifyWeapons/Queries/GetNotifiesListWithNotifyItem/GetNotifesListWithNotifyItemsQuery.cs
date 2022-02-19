using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPCMMS.Application.Features.NotifyWeapons.Queries.GetNotifiesListWithNotifyItem
{
    public class GetNotifesListWithNotifyItemsQuery : IRequest<List<NotifyNotifyItemListVm>>
    {
        public bool IncludeHistory { get; set; }
    }
}
