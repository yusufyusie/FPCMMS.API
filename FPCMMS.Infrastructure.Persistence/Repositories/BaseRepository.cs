using FPCMMS.Application.Contracts.Generic;
using FPCMMS.Application.Contracts.Persistence;
using FPCMMS.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FPCMMS.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly MaterialDbContext _dbContext;
        public BaseRepository(MaterialDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
        public async virtual Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size)
        {
            return await _dbContext.Set<T>()
                                   .Skip((page - 1) * size)
                                   .Take(size).AsNoTracking().ToListAsync();
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
