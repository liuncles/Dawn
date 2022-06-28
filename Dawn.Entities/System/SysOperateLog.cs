namespace Dawn.Entities.System
{
    /// <summary>
    /// 操作日志表
    /// </summary>
    [SugarTable("sys_operate_log")]
    public class SysOperateLog : EntityBase
    {
        /// <summary>
        /// 区域名
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? Area { get; set; }

        /// <summary>
        /// 区域控制器名
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? Controller { get; set; }

        /// <summary>
        /// Action名称
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? Action { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? IPAddress { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? Description { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime? LogTime { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? UserName { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        [SugarColumn(IsIgnore = true)]
        public virtual SysUser? User { get; set; }
    }
}
