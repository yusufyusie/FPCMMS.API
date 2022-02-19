using FPCMMS.Application.Contracts.Persistence;
using FPCMMS.Domain.Entities;
using FPCMMS.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FPCMMS.Infrastructure.Persistence.Repositories
{
    public class NotifyItemRepository : BaseRepository<NotifyItem>, INotifyItemRepository
    {
        public NotifyItemRepository(MaterialDbContext dbContext) : base(dbContext)
        {

        }        
        
    }
}
