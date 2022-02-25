using FPCMMS.Application.Contracts.Persistence.Weapon;
using FPCMMS.Domain.Entities;
using FPCMMS.Infrastructure.Persistence.Contexts;

namespace FPCMMS.Infrastructure.Persistence.Repositories
{
    public class NotifyDetailRepository : BaseRepository<NotifyItem>, INotifyDetailRepository
    {
        public NotifyDetailRepository(MaterialDbContext dbContext) : base(dbContext)
        {

        }        
        
    }
}
