using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace miniapi_webapi.Infrastructure.Repository
{

    /// <summary>
    /// 仓储接口定义
    /// </summary>
    public interface IRepository
    {

    }

    public interface IRepostiory<TEntity, Guid> : IRepository,IAsyncDisposable  where TEntity : class, new()
    {
        Task RemoveAsync(TEntity t);
        Task RemoveAsync(List<TEntity> entities);
        Task AddAsync(TEntity t);
        Task AddAsync(List<TEntity> entities);
        Task<List<TEntity>> GetAllListAsync();
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate);
        Task UpdateAsync(TEntity t);
    }

    /// <summary>
    /// 默认Guid主键类型仓储
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepositoryBase<TEntity> : IRepostiory<TEntity, Guid> where TEntity : class, new()
    {

    }
}