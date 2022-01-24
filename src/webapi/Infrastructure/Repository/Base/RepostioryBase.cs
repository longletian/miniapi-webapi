using System.Linq.Expressions;

namespace miniapi_webapi.Infrastructure.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, new()
    {
        private readonly IDbContextFactory<AppDbContext> dbContextFactory;
        public RepositoryBase(IDbContextFactory<AppDbContext> _appDbContext)
        {
            dbContextFactory = _appDbContext ?? throw new ArgumentException(nameof(AppDbContext));
        }

        public async Task RemoveAsync(TEntity t)
        {
            using (var appDbContext = dbContextFactory.CreateDbContext())
            {
                appDbContext.Remove(t);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveAsync(List<TEntity> entities)
        {
            if (entities.Count() <= 0)
            {
                throw new ArgumentNullException(nameof(entities));
            }
            using (var appDbContext = dbContextFactory.CreateDbContext())
            {
                appDbContext.RemoveRange(entities);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task AddAsync(TEntity t)
        {
            using (var appDbContext = dbContextFactory.CreateDbContext())
            {
                await appDbContext.AddAsync(t);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task AddAsync(List<TEntity> entities)
        {
            if (entities.Count() <= 0)
            {
                throw new ArgumentNullException(nameof(entities));
            }
            using (var appDbContext = dbContextFactory.CreateDbContext())
            {
                await appDbContext.AddRangeAsync(entities);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<TEntity>> GetAllListAsync()
        {
            using (var appDbContext = dbContextFactory.CreateDbContext())
            {
                return await appDbContext.Set<TEntity>().ToListAsync();
            }
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using (var appDbContext = dbContextFactory.CreateDbContext())
            {
                return await appDbContext.Set<TEntity>().Where(predicate).ToListAsync();
            }
        }

        public ValueTask DisposeAsync()
        {
            using (var appDbContext = dbContextFactory.CreateDbContext())
            {
                return appDbContext.DisposeAsync();
            };
        }

        public async Task UpdateAsync(TEntity t)
        {
            using (var appDbContext = dbContextFactory.CreateDbContext())
            {
                appDbContext.Update(t);
                await appDbContext.SaveChangesAsync();
            }
        }
    }
}