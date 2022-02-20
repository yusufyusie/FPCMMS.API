using FPCMMS.Application.Contracts.Generic;
using FPCMMS.Domain.Entities;

namespace FPCMMS.Application.Contracts.Persistence
{
    public interface INotifyWeaponRepository : IGenericRepository<Notify>
    {
        Task<List<Notify>> GetNotifiesWithNotifyItems(bool includePassedNotifyItems);
    }
}
