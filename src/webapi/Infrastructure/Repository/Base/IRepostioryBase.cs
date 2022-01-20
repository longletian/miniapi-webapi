namespace miniapi_webapi.Infrastructure.Repository
{

    /// <summary>
    /// 仓储接口定义
    /// </summary>
    public interface IRepository
    {

    }

    public interface IRepostiory<TEntity, Guid> : IRepository where TEntity : class, new()
    {

    }

    /// <summary>
    /// 默认Guid主键类型仓储
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepositoryBase<TEntity> : IRepostiory<TEntity, Guid> where TEntity : class, new()
    {

    }
}