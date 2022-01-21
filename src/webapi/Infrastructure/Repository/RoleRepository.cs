namespace miniapi_webapi.Infrastructure.Repository
{
    public class RoleRepository:RepositoryBase<RoleEntity>,IRoleRepository
    {
        public RoleRepository(IDbContextFactory<AppDbContext> _appDbContext) : base(_appDbContext)
        {
            
        }
        
    }
}
