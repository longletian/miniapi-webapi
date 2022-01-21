using System.Threading.Tasks;
using HotChocolate.Types;
using miniapi_webapi.Infrastructure.Graphql.DataLoader;

namespace miniapi_webapi.Infrastructure.Graphql
{
    public class UserQuery
    {
        public async Task<UserEntity> GetUserData(Guid id, UserDataLoader userDataLoader)
        {
            return await userDataLoader.LoadAsync(id);
        }
    }
}