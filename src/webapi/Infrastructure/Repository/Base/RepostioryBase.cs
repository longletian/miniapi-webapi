namespace miniapi_webapi.Infrastructure.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class,new ()
    {
        private readonly AppDbContext appDbContext;

        public RepositoryBase(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }

        
    }
}