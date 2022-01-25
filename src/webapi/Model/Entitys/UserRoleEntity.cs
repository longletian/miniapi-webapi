using System.ComponentModel.DataAnnotations.Schema;

namespace miniapi_webapi.Model.Entitys
{

    [Table("t_user_role")]
    public class UserRoleEntity
    {
        public UserRoleEntity(Guid userId, Guid roleId)
        {
            this.UserId = userId;
            this.RoleId = roleId;
        }

        [NotMapped]
        public UserEntity UserEntity { get; set; } = null!;

        public Guid UserId { get; set; }

        [NotMapped]
        public RoleEntity RoleEntity { get; set; } = null!;

        public Guid RoleId { get; set; }

    }
}
