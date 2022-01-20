namespace miniapi_webapi.Infrastructure.Repository
{
    public interface IDepartmentRepositpory:IRepositoryBase<DepartmentEntity>
    {
        /// <summary>
        /// 获取所有的部门
        /// </summary>
        /// <returns></returns>
        Task<List<DepartmentEntity>> GetAllDepartmentEntitiesAsync(Guid? parentId);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="dto">实体</param>
        /// <returns></returns>
        Task<DepartmentEntity> InsertAsync(DepartmentEntity dto);

        // <summary>
        /// 修改
        /// </summary>
        /// <param name="dto">实体</param>
        /// <returns></returns>
        Task<DepartmentEntity> UpdateAsync(DepartmentEntity dto);

        /// <summary>
        /// 根据Id集合批量删除
        /// </summary>
        /// <param name="ids">Id集合</param>
        Task DeleteBatchAsync(List<Guid> ids);

        /// <summary>
        ///  删除
        /// </summary>
        /// <param name="id">Id</param>
        Task<DepartmentEntity> DeleteAsync(Guid id);

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        Task<DepartmentEntity> GetAsync(Guid id);
    }
}
