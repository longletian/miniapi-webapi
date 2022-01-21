namespace miniapi_webapi.Infrastructure.Repository
{
    public class UserRepository:RepositoryBase<UserEntity>,IUserRepository
    {
        public UserRepository(IDbContextFactory<AppDbContext> _appDbContext) : base(_appDbContext)
        {
        }
    }
}
