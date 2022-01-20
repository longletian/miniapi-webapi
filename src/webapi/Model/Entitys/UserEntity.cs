using System.ComponentModel.DataAnnotations.Schema;

namespace miniapi_webapi.Model.Entitys
{

    [Table("t_user")]
    public class UserEntity
    {
        public UserEntity()
        {
            RoleEntities = new List<RoleEntity>();
            DepartmentEntity = new DepartmentEntity();
        }

        public Guid Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Column(TypeName = "varchar(100)")]
        public string? Name { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [Column(TypeName = "varchar(100)")]
        public string? NickName { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        [Column(TypeName = "varchar(100)")]
        public string? Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Column(TypeName = "varchar(100)")]
        public string? AccountPwd { get; set; }

        public DateTime GmtCreate { get; set; }

        public DateTime GmtModified { get; set; }

        /// <summary>
        /// 邮箱地址
        /// </summary>
        [Column(TypeName = "varchar(100)")]
        public string? EMail { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Column(TypeName = "varchar(100)")]
        public string? MobileNumber { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool IsEnable { get; set; }

        public bool IsDeleted { get; set; }

        public int OrderSort { get; set; }

        public Guid DepartmentId { get; set; }

        [NotMapped]
        public DepartmentEntity DepartmentEntity { get; set; }

        [NotMapped]
        public virtual ICollection<RoleEntity> RoleEntities { get; set; }

        /// <summary>
        /// 多对多.net5
        /// </summary>
        [NotMapped]
        public List<UserRoleEntity> UserRoleEntities { get; set; }
    }
}
