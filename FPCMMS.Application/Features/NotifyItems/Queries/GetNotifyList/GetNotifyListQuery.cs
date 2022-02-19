using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPCMMS.Application.Features.NotifyItems.Queries.GetNotifyList
{
    public class GetNotifyListQuery : IRequest<List<NotifyListVm>>
    {
    }
}
