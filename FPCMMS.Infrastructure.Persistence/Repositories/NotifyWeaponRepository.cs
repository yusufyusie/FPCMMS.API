using FPCMMS.Application.Contracts.Persistence;
using FPCMMS.Domain.Entities;
using FPCMMS.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FPCMMS.Infrastructure.Persistence.Repositories
{
    public class NotifyWeaponRepository : BaseRepository<Notify>, INotifyWeaponRepository
    {
        public NotifyWeaponRepository(MaterialDbContext dbContext) : base(dbContext)
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
