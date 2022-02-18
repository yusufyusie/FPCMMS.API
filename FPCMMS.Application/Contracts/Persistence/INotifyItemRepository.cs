using FPCMMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPCMMS.Application.Contracts.Persistence
{
    public interface INotifyItemRepository:IGenericRepository<NotifyItem>
    {
        Task<List<NotifyItem>> GetNotifyItemsWithEvents(bool includePassedEvents);
         void CreateNotifyItemForNotifyWeapon(int notifyId, NotifyItem notifyItem);
    }
}
