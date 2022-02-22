using MediatR;

namespace FPCMMS.Application.Features.NotifyItems.Queries.GetNotifyDetail
{
    public class GetNotifyDetailQuery : IRequest<NotifyDetailVm>
    {
        public int Id { get; set; }
    }
}
