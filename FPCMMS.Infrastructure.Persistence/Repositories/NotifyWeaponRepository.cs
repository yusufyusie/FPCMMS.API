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
        public async Task<List<Notify>> GetNotifyWeaponsWithEvents(bool includePassedEvents)
        {
            var allNotifyWeapons = await _dbContext.Notifies.ToListAsync();
            return allNotifyWeapons;
        }
    }
}
