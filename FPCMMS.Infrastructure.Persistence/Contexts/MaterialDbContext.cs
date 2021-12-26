using Microsoft.EntityFrameworkCore;

namespace FPCMMS.Infrastructure.Persistence.Contexts
{
    public class MaterialDbContext : DbContext
    {
        //private readonly ILoggerManager _loggerManager;
        public MaterialDbContext(DbContextOptions<MaterialDbContext> options) : base(options)
        {

        }
        //public MaterialDbContext(DbContextOptions<MaterialDbContext> options, ILoggerManager loggerManager) : base(options)
        //{
        //    _loggerManager = loggerManager;
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        //public DbSet<StoreItem> StoreItems { get; set; }
        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        //{
        //    foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        //    {
        //        switch (entry.State)
        //        {
        //            case EntityState.Added:
        //                entry.Entity.CreatedDate = DateTime.Now;
        //                entry.Entity.CreatedBy = _loggerManager.UserId;
        //                break;
        //            case EntityState.Modified:
        //                entry.Entity.LastModifiedDate = DateTime.Now;
        //                entry.Entity.LastModifiedBy = _loggerManager.UserId;
        //                break;
        //        }
        //    }
        //    return base.SaveChangesAsync(cancellationToken);
        //}
    }
}
