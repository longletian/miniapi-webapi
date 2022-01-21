using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;

namespace miniapi_webapi.Infrastructure.Graphql
{
    public class DepartmentQuery:ObjectType<DepartmentEntity>
    {
        /// <summary>
        /// 获取所有的部门
        /// </summary>
        /// <returns></returns>
        public async Task<List<DepartmentEntity>> GetAllDepartmentEntitiesAsync([ScopedService] IRepositoryBase<DepartmentEntity>deparRepository,Guid? parentId)
        {
            var departmentEntities = await deparRepository.GetAllListAsync();
            departmentEntities = departmentEntities.Where((x) => x.IsDeleted == 0).ToList();
            if (parentId.HasValue)
            {
                departmentEntities= departmentEntities.Where((x) => x.Id == parentId.Value).ToList();
            }
            return departmentEntities.AsEnumerable().ToList();
        }
        
        
    }
}