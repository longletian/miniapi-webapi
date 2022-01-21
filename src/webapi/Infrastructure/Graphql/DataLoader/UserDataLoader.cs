using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;

namespace miniapi_webapi.Infrastructure.Graphql.DataLoader
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
            List<UserEntity> userEntities = userRepository.GetAllListAsync().Result.ToList();
            return userEntities
                ?.Where(s => keys.Contains(s.Id))
                .ToDictionary(t => t.Id);
        }
    }
}