namespace miniapi_webapi.Model
{
    /// <summary>
    /// 注册用户实体
    /// </summary>
    public class UserInput
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

        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string? EMail { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string? MobileNumber { get; set; }

        public Guid DepartmentId { get; set; }

    }


    /// <summary>
    /// 登录账号实体
    /// </summary>
    /// <param name="account"></param>
    /// <param name="accountPwd"></param>
    /// <param name="code"></param>
    public record UseLoginInput(string account, string accountPwd, string code);


}
