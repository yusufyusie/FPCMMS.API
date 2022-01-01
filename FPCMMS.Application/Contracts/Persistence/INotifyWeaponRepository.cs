using FPCMMS.Domain.Entities;

namespace FPCMMS.Application.Contracts.Persistence
{
    public interface INotifyWeaponRepository : IGenericRepository<NotifyWeapon>
    {
        Task<List<NotifyWeapon>> GetNotifyWeaponsWithEvents(bool includePassedEvents);
    }
}
