namespace miniapi_webapi.Infrastructure
{
    public static class SeedData
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());
          
            context.Database.EnsureDeleted();
            
            context.Database.EnsureCreated();

            var departmentId = Guid.NewGuid();
            //增加一个部门
            await context.DepartmentEntities.AddAsync(
                 new DepartmentEntity
                 {
                     Id = departmentId,
                     Name = "集团总部",
                     ParentId = null
                 }
             );

            await context.PermissionEntities.AddRangeAsync(
                   new PermissionEntity
                   {
                       Id = Guid.NewGuid(),
                       Name = "组织机构管理",
                       Code = "Department",
                       ParentId = null,
                       OrderSort = 1,
                       GmtCreate = DateTime.Now,
                       GmtModified = DateTime.Now,
                       Icon = "fa fa-link"
                   },
                   new PermissionEntity
                   {
                       Id = Guid.NewGuid(),
                       Name = "角色管理",
                       Code = "Role",
                       ParentId = null,
                       OrderSort = 2,
                       GmtCreate = DateTime.Now,
                       GmtModified = DateTime.Now,
                       Icon = "fa fa-link"
                   },
                   new PermissionEntity
                   {
                       Id = Guid.NewGuid(),
                       Name = "用户管理",
                       Code = "User",
                       ParentId = null,
                       OrderSort = 3,
                       GmtCreate = DateTime.Now,
                       GmtModified = DateTime.Now,
                       Icon = "fa fa-link"
                   },
                   new PermissionEntity
                   {
                       Id = Guid.NewGuid(),
                       Name = "功能管理",
                       Code = "Department",
                       ParentId = null,
                       OrderSort = 4,
                       GmtCreate = DateTime.Now,
                       GmtModified = DateTime.Now,
                       Icon = "fa fa-link"
                   }
               );

            var roleId = Guid.NewGuid();
            await context.RoleEntities.AddAsync(
                new RoleEntity
                {
                    Id = roleId,
                    Name = "超级管理员",
                    GmtCreate = DateTime.Now,
                    GmtModified = DateTime.Now,
                    RolePermissionEntities = context.PermissionEntities.Local.Select(i => new RolePermissionEntity(roleId, i.Id)).ToList()
                }
            );

            var userId = Guid.NewGuid();
            //增加一个超级管理员用户
            await context.UserEntities.AddAsync(
                new UserEntity
                {
                    Id = userId,
                    Account = "admin",
                    AccountPwd = "123456", //暂不进行加密
                    Name = "超级管理员",
                    DepartmentId = departmentId,
                    GmtCreate = DateTime.Now,
                    GmtModified = DateTime.Now,
                    UserRoleEntities = new List<UserRoleEntity>()
                    {
                        new UserRoleEntity(userId,roleId)
                    }
                }
            );

            await context.SaveChangesAsync();
        }
    }
}
