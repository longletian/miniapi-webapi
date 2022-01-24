namespace miniapi_webapi.Infrastructure.Graphql
{
    public class UserDataLoader:BatchDataLoader<Guid, UserEntity>
    {
        private readonly IUserRepository userRepository;
        
        public UserDataLoader(IBatchScheduler batchScheduler, IUserRepository _userRepository,DataLoaderOptions? options = null) : base(batchScheduler, options)
        {
            userRepository = _userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        protected async override Task<IReadOnlyDictionary<Guid, UserEntity>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            var userEntities = await userRepository.GetAllListAsync();
            return userEntities
                ?.Where(s => keys.Contains(s.Id))
                ?.ToDictionary(t => t.Id) ?? throw new ArgumentNullException("");
        }
    }
}