using System.Linq.Expressions;
using System.Threading.Tasks;

namespace miniapi_webapi.Infrastructure.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class,new ()
    {
        private readonly AppDbContext appDbContext;

        public RepositoryBase(IDbContextFactory<AppDbContext> _appDbContext)
        {
            using (appDbContext = _appDbContext.CreateDbContext()) ;
        }
        
        public Task RemoveAsync(TEntity t)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(TEntity t)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAllListAsync()
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        
        public ValueTask DisposeAsync()
        {
            return appDbContext.DisposeAsync();
        }
    }
}