using FPCMMS.Application.Contracts.Persistence;
using FPCMMS.Domain.Entities;
using FPCMMS.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FPCMMS.Infrastructure.Persistence.Repositories
{
    public class NotifyWeaponRepository : BaseRepository<NotifyWeapon>, INotifyWeaponRepository
    {
        public NotifyWeaponRepository(MaterialDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<List<NotifyWeapon>> GetNotifyWeaponsWithEvents(bool includePassedEvents)
        {
            var allNotifyWeapons = await _dbContext.NotifyWeapons.ToListAsync();
            return allNotifyWeapons;
        }
    }
}
