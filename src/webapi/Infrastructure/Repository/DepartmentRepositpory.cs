using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace miniapi_webapi.Infrastructure.Repository
{
    public class DepartmentRepositpory:RepositoryBase<DepartmentEntity>, IDepartmentRepositpory
    {
        private readonly AppDbContext appDbContext;
        public DepartmentRepositpory(IDbContextFactory<AppDbContext> _appDbContext) : base(_appDbContext)
        {
            using (appDbContext = _appDbContext.CreateDbContext())
            {
            }
        }
        
        /// <summary>
        /// 获取所有的部门
        /// </summary>
        /// <returns></returns>
        public async Task<List<DepartmentEntity>> GetAllDepartmentEntitiesAsync(Guid? parentId)
        {
            List<DepartmentEntity> departmentEntities = await appDbContext.DepartmentEntities.Where((x) => x.IsDeleted == 0).ToListAsync();
            if (parentId.HasValue)
            {
                departmentEntities= departmentEntities.Where((x) => x.Id == parentId.Value).ToList();
            }
            return departmentEntities;
        }

        /// <summary>
        /// 根据Id集合批量删除
        /// </summary>
        /// <param name="ids">Id集合</param>
        public async Task DeleteBatchAsync(List<Guid> ids)
        {
            List<DepartmentEntity> departmentEntities = await appDbContext.DepartmentEntities.Where((x) => x.IsDeleted == 0 && ids.Contains(x.Id)).ToListAsync();
            appDbContext.RemoveRange(departmentEntities);
            await appDbContext.SaveChangesAsync();
        }
        
        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public async Task<DepartmentEntity> GetAsync(Guid id)
        {
            return await appDbContext.DepartmentEntities.Where((x) => x.IsDeleted == 0 && x.Id == id).FirstOrDefaultAsync()??throw new ArgumentException("");
        }
    }
}
