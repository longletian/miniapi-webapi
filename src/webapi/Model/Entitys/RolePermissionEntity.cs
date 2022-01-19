namespace miniapi_webapi.Model.Entitys
{

    [Table("t_role_permission")]
    public class RolePermissionEntity
    {
        public RolePermissionEntity(Guid roleId, Guid permissionId)
        {
            RoleId = roleId;
            PermissionId = permissionId;
        }

        [NotMapped]
        public RoleEntity RoleEntity { get; set; }

        public Guid RoleId { get; set; }

        [NotMapped]
        public PermissionEntity PermissionEntity { get; set; }

        public Guid PermissionId { get; set; }

    }
}
