

namespace miniapi_webapi.Model
{
    [Table("t_role")]
    public class RoleEntity
    {
        public RoleEntity()
        {
            PermissionEntities = new List<PermissionEntity>();
            UserRoleEntities = new List<UserRoleEntity>();
            RolePermissionEntities = new List<RolePermissionEntity>();
        }

        public Guid Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? Name { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string? Description { get; set; }

        public DateTime GmtCreate { get; set; }

        public DateTime GmtModified { get; set; }

        public bool IsDeleted { get; set; }

        public int OrderSort { get; set; }

        [NotMapped]
        public virtual ICollection<PermissionEntity> PermissionEntities { get; set; }

        [NotMapped]
        public virtual ICollection<UserEntity> UserEntities { get; set; }

        /// <summary>
        /// 多对多.net5
        /// </summary>
        [NotMapped]
        public virtual List<UserRoleEntity> UserRoleEntities { get; set; }

        /// <summary>
        /// 多对多.net5
        /// </summary>
        [NotMapped]
        public virtual List<RolePermissionEntity> RolePermissionEntities { get; set; }
    }
}
