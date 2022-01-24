namespace miniapi_webapi.Infrastructure.Graphql
{
    public class UserQuery
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<UserEntity> GetUserData(Guid id, UserDataLoader userDataLoader)
        {
            return await userDataLoader.LoadAsync(id);
        }

        /// <summary>
        /// 一对一 获取用户数据
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="context"></param>
        /// <param name="userRepository"></param>
        /// <returns></returns>
        [UseDbContext(typeof(AppDbContext))]
        public async Task<UserEntity> GetUserV1Data(Guid guid, IResolverContext context, [ScopedService] IUserRepository userRepository)
        {
            return await context.BatchDataLoader<Guid, UserEntity>(
               async (keys, ct) =>
               {
                   var result = await userRepository.GetAllListAsync();
                   return result.Where(p => keys.Contains(p.Id)).ToDictionary(x => x.Id);
               })
           .LoadAsync(guid);
        }

        /// <summary>
        /// 一对多 获取部门下面的用户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="context"></param>
        /// <param name="userRepository"></param>
        /// <returns></returns>

        [UseDbContext(typeof(AppDbContext))]
        public async Task<IEnumerable<UserEntity>> GetUserListByDepartMentIdAsync(Guid id, IResolverContext context, [Service] IUserRepository userRepository)
        {
            return await context.GroupDataLoader<Guid, UserEntity>(
                async (keys, ct) =>
                {
                    var result = await userRepository.GetAllListAsync();
                    result = result.Where((c) => keys.Contains(c.DepartmentId) && c.IsDeleted == false).ToList();
                    return result.ToLookup(t => t.DepartmentId);
                })
            .LoadAsync(id);
        }
    }
}