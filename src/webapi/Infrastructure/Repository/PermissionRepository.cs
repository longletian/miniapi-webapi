namespace miniapi_webapi.Infrastructure.Repository
{
    public class PermissionRepository:RepositoryBase<PermissionEntity>,IPermissionRepository
    {
        public PermissionRepository(IDbContextFactory<AppDbContext> _appDbContext) : base(_appDbContext)
        {
            
        }
    }
}
