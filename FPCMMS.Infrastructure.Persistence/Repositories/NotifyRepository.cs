using FPCMMS.Application.Contracts.Persistence;
using FPCMMS.Application.Contracts.Persistence.Weapon;
using FPCMMS.Domain.Entities;
using FPCMMS.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FPCMMS.Infrastructure.Persistence.Repositories
{
    public class NotifyRepository : BaseRepository<Notify>, INotifyRepository
    {
        public NotifyRepository(MaterialDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<List<Notify>> GetNotifiesWithNotifyItems(bool includePassedEvents)
        {
            var allNotifies = await _dbContext.Notifies.Include(x => x.NotifyItems).ToListAsync();
            if (!includePassedEvents)
            {
                allNotifies.ForEach(p => p.NotifyItems.ToList());
            }
            return allNotifies;
        }
    }
}
