using Mapster;

namespace miniapi_webapi.Infrastructure.Graphql
{
    public class UserMutation
    {
        public async Task<UserEntity> AddUser(UserInput userInput, [Service] IUserRepository userRepository)
        {
            DateTime dateTime = DateTime.Now;
            UserEntity userEntity = userInput.Adapt<UserEntity>();
            userEntity.GmtCreate = dateTime;
            userEntity.GmtModified = dateTime;
            userEntity.IsDeleted = false;
            await userRepository.AddAsync(userEntity);
            return userEntity;
        }


        [UseDbContext(typeof(AppDbContext))]
        public async Task<UserOutput?> UserLoginAsync(UseLoginInput useLoginInput, [ScopedService] AppDbContext context)
        {
            UserEntity userEntity = await context.UserEntities
                .Include(e => e.RoleEntities)
                .Where((c) => c.IsDeleted == false && c.Account == useLoginInput.account && c.AccountPwd == useLoginInput.accountPwd)
                .FirstOrDefaultAsync();
            UserOutput userOutput = userEntity!.Adapt<UserOutput>();
            userOutput.RoleItemDtos = userEntity?.RoleEntities.Select((c) => new RoleItemDto { Id = c.Id, Name = c.Name }).ToList();
            return userOutput;
        }
    }
}
