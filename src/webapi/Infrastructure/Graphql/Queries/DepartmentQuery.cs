namespace miniapi_webapi.Infrastructure.Graphql
{
    public class DepartmentQuery
    {

        /// <summary>
        /// 获取所有的部门
        /// </summary>
        /// <returns></returns>
        public async Task<List<DepartmentEntity>> GetAllDepartmentEntitiesAsync([Service] IDepartmentRepositpory deparRepository, Guid? parentId)
        {
            var departmentEntities = await deparRepository.GetAllListAsync();
            departmentEntities = departmentEntities.Where((x) => x.IsDeleted == 0).ToList();
            if (parentId.HasValue)
            {
                departmentEntities = departmentEntities.Where((x) => x.Id == parentId.Value).ToList();
            }
            return departmentEntities.AsQueryable().ToList();
        }

    }
}