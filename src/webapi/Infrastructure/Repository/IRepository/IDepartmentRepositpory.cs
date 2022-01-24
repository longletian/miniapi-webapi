namespace miniapi_webapi.Infrastructure.Repository
{
    public interface IDepartmentRepositpory:IRepositoryBase<DepartmentEntity>
    {
        /// <summary>
        /// 根据Id集合批量删除
        /// </summary>
        /// <param name="ids">Id集合</param>
        Task DeleteBatchAsync(List<Guid> ids);

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        Task<DepartmentEntity> GetAsync(Guid id);
    }
}
