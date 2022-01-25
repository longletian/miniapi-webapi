namespace miniapi_webapi.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<UserEntity> UserEntities =>Set<UserEntity>();
        public DbSet<RoleEntity> RoleEntities => Set<RoleEntity>();
        public DbSet<PermissionEntity> PermissionEntities => Set<PermissionEntity>();
        public DbSet<UserRoleEntity> UserRoles => Set<UserRoleEntity>();
        public DbSet<RolePermissionEntity> RolePermissions => Set<RolePermissionEntity>();
        public DbSet<DepartmentEntity> DepartmentEntities => Set<DepartmentEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentEntity>()
                .HasMany(p => p.UserEntities)
                .WithOne(p => p.DepartmentEntity)
                .HasForeignKey(p => p.DepartmentId);

            modelBuilder.Entity<UserEntity>()
             .HasMany(p => p.RoleEntities)
             .WithMany(p => p.UserEntities)
             .UsingEntity<UserRoleEntity>(
                 j => j
                     .HasOne(pt => pt.RoleEntity)
                     .WithMany(t => t.UserRoleEntities)
                     .HasForeignKey(pt => pt.RoleId),
                 j => j
                     .HasOne(pt => pt.UserEntity)
                     .WithMany(p => p.UserRoleEntities)
                     .HasForeignKey(pt => pt.UserId),
                 j =>
                 {
                     j.HasKey(t => new { t.UserId, t.RoleId });
                 });


            modelBuilder.Entity<RoleEntity>()
            .HasMany(p => p.PermissionEntities)
            .WithMany(p => p.RoleEntities)
            .UsingEntity<RolePermissionEntity>(
                j => j
                    .HasOne(pt => pt.PermissionEntity)
                    .WithMany(t => t.RolePermissionEntities)
                    .HasForeignKey(pt => pt.PermissionId),
                j => j
                    .HasOne(pt => pt.RoleEntity)
                    .WithMany(p => p.RolePermissionEntities)
                    .HasForeignKey(pt => pt.RoleId),
                j =>
                {
                    j.HasKey(t => new { t.RoleId, t.PermissionId });
                });

            //foreach (var entity in modelBuilder.Model.GetEntityTypes())
            //{
            //    modelBuilder.Entity(entity.Name, builder =>
            //    {
            //        //builder.ToTable(entity.ClrType.Name.ToLower());
            //        foreach (var property in entity.GetProperties())
            //        {
            //            //builder.Property(property.Name).HasColumnName(property.Name.ToLower());
            //        }
            //    });
            //}
        }
    }
}
