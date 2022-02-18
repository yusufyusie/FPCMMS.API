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

        public void CreateNotifyItemForNotifyWeapon(int notifyId, NotifyItem notifyItem)
        {
            notifyItem.NotifyId = notifyId;
            AddAsync(notifyItem);
        }

        public async Task<List<NotifyItem>> GetNotifyItemsWithEvents(bool includePassedEvents)
        {
            var allNotifyItems = await _dbContext.NotifyItems.ToListAsync();
            return allNotifyItems;
        }
    }
}
