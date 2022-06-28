namespace Dawn.Entities.System
{
    /// <summary>
    /// 用户访问趋势日志
    /// </summary>
    [SugarTable("sys_accesstrend_log")]
    public class SysAccessTrendLog : EntityTKeyBase<int>
    {
        /// <summary>
        /// 用户
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true, ColumnDataType = "nvarchar")]
        public string? User { get; set; }

        /// <summary>
        /// 次数
        /// </summary>
        public int? Count { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdatedTime { get; set; } = DateTime.Now;
    }
}
