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
        /// 新增
        /// </summary>
        /// <param name="dto">实体</param>
        /// <returns></returns>
        public async Task<DepartmentEntity> InsertAsync(DepartmentEntity dto)
        {
            await appDbContext.AddAsync(dto);
            await appDbContext.SaveChangesAsync();
            return dto;
        }
        
        // <summary>
        /// 修改
        /// </summary>
        /// <param name="dto">实体</param>
        /// <returns></returns>
        public async Task<DepartmentEntity> UpdateAsync(DepartmentEntity dto)
        {
            appDbContext.Update(dto);
            await appDbContext.SaveChangesAsync();
            return dto;
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
        ///  删除
        /// </summary>
        /// <param name="id">Id</param>
        public async Task<DepartmentEntity?> DeleteAsync(Guid id)
        {
            DepartmentEntity departmentEntity = await appDbContext.DepartmentEntities.Where((x) => x.IsDeleted == 0 && x.Id == id).FirstOrDefaultAsync();
            if (departmentEntity != null)
            {
                appDbContext.Remove(departmentEntity);
                await appDbContext.SaveChangesAsync();
                return departmentEntity;
            }
            return default(DepartmentEntity);
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
