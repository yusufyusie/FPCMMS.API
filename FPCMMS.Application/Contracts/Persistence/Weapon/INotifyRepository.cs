using FPCMMS.Application.Contracts.Generic;
using FPCMMS.Domain.Entities;

namespace FPCMMS.Application.Contracts.Persistence.Weapon
{
    public interface INotifyRepository : IGenericRepository<Notify>
    {
        Task<List<Notify>> GetNotifiesWithNotifyItems(bool includePassedNotifyItems);
    }
}
