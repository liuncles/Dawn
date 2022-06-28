namespace Dawn.Entities.System
{
    /// <summary>
    /// 登录日志表
    /// </summary>
    [SugarTable("sys_loginLog")]
    public class SysLoginLog
    {
        /// <summary>
        /// 状态
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? IPAddress { get; set; }

        /// <summary>
        /// IP地点
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? IPSite { get; set; }

        /// <summary>
        /// 浏览器
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? Browser { get; set; }

        /// <summary>
        /// 系统
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? OS { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? Description { get; set; }

        [NotMapped]
        public string? UserName { get; set; }
    }
}
