namespace miniapi_webapi.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<UserEntity> userEntities { get; set; }
        public DbSet<RoleEntity> roleEntities { get; set; }
        public DbSet<PermissionEntity> permissionEntities { get; set; }
        public DbSet<UserRoleEntity> userRoles { get; set; }
        public DbSet<RolePermissionEntity> rolePermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
