namespace Dawn.Entities.System
{
    /// <summary>
    /// 用户表
    /// </summary>
    [SugarTable("sys_user")]
    public class SysUser: UserBase<int>
    {
        public SysUser() { }

        public SysUser(string userName, string password)
        {
            UserName = userName;
            Password = password;
            Status = 0;
            IsDeleted = false;
            CreatedTime = DateTime.Now;
            ModifiedTime = DateTime.Now;
            LastErrTime = DateTime.Now;
            ErrorCount = 0;
        }

        /// <summary>
        /// 用户名
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? Password { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? UserNick { get; set; }

        /// <summary>
        /// 性别（0未知，1男，2女）
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? Portrait { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? Email { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? Phone { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? Description { get; set; }

        /// <summary>
        /// 用户状态（0正常，1停用，2锁定）
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        ///错误次数 
        /// </summary>
        public int? ErrorCount { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastErrTime { get; set; }
    }
}
