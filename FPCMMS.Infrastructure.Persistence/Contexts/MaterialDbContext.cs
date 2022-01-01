using FPCMMS.Application.Contracts;
using FPCMMS.Domain.Common;
using FPCMMS.Domain.Entities;
using FPCMMS.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace FPCMMS.Infrastructure.Persistence.Contexts
{
    public class MaterialDbContext : DbContext
    {
        private readonly ILoggedInUserService _loggedInUserService;
        public MaterialDbContext(DbContextOptions<MaterialDbContext> options) : base(options)
        {

        }
        public MaterialDbContext(DbContextOptions<MaterialDbContext> options, ILoggedInUserService loggedInUserService) : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }
        public DbSet<NotifyWeapon> NotifyWeapons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new NotifyWeaponConfiguration());
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = DateTime.Now;
                        entry.Entity.ModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
