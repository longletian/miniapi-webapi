namespace miniapi_webapi.Model
{
    public class UserOutput
    {
      
        public Guid Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string? NickName { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string? Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string? AccountPwd { get; set; }

        public DateTime GmtCreate { get; set; }

        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string? EMail { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string? MobileNumber { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool IsEnable { get; set; }

        public int OrderSort { get; set; }

        public Guid DepartmentId { get; set; }

        public List<RoleItemDto>? RoleItemDtos {get;set;}
        
    }


    public class RoleItemDto
    {
        public Guid Id { get; set; }
        
        public string? Name { get; set; }        
        
    }
}
