namespace Dawn.Entities.System
{
    /// <summary>
    /// 模块表
    /// </summary>
    [SugarTable("sys_modules")]
    public class SysModules : ModulesBase<int>
    {
        public SysModules() { }

        /// <summary>
        /// 编号
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? Name { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? LinkUrl { get; set; }

        /// <summary>
        /// 区域名称
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? Area { get; set; }

        /// <summary>
        /// 控制器名称
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? Controller { get; set; }

        /// <summary>
        /// Action名称
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? Action { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? Icon { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int? Sorts { get; set; }

        /// <summary>
        /// /描述
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? Description { get; set; }

        /// <summary>
        /// 是否是右侧菜单
        /// </summary>
        public bool? IsMenu { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool? Enabled { get; set; }
    }
}
