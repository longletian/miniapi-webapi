namespace miniapi_webapi.Model
{
    [Table("t_permission")]
    public class PermissionEntity
    {
        public PermissionEntity()
        {
            RolePermissionEntities = new List<RolePermissionEntity>();
            RoleEntities=new List<RoleEntity>();
        }

        public Guid Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? Name { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string? Description { get; set; }

        public Guid? ParentId { get; set; }

        /// <summary>
        /// 菜单编码
        /// </summary>
        [Column(TypeName = "varchar(100)")]
        public string? Code { get; set; }

        /// <summary>
        /// 菜单地址
        /// </summary>
        [Column(TypeName = "varchar(100)")]
        public string? Url { get; set; }

        /// <summary>
        /// 类型：0导航菜单；1操作按钮。
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        [Column(TypeName = "varchar(100)")]
        public string? Icon { get; set; }

        public DateTime GmtCreate { get; set; }

        public DateTime GmtModified { get; set; } 

        public bool IsDeleted { get; set; }

        public bool IsEnable { get; set; }

        public int OrderSort { get; set; }

        /// <summary>
        /// 多对多.net5
        /// </summary>
        public List<RolePermissionEntity> RolePermissionEntities { get; set; }


        public virtual ICollection<RoleEntity> RoleEntities { get; set; }

    }
}
