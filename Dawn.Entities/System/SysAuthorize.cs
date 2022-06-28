namespace Dawn.Entities.System
{
    /// <summary>
    /// 授权表
    /// </summary>
    [SugarTable("sys_authorize")]
    public class SysAuthorize : AuthorizeBase<int>
    {
        public SysAuthorize() { }

        /// <summary>
        /// 编号
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? Code { get; set; }

        /// <summary>
        /// 模块显示名（如用户页、编辑(按钮)、删除(按钮)）
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? Name { get; set; }

        /// <summary>
        /// 是否是按钮
        /// </summary>
        public bool? IsButton { get; set; } = false;

        /// <summary>
        /// 是否是隐藏菜单
        /// </summary>
        public bool? IsHide { get; set; } = false;

        /// <summary>
        /// 是否keepAlive
        /// </summary>
        public bool? IskeepAlive { get; set; } = false;


        /// <summary>
        /// 按钮事件
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? Func { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int? Sorts { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? Icon { get; set; }

        /// <summary>
        /// 描述    
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? Description { get; set; }

        /// <summary>
        /// 激活状态
        /// </summary>
        public bool? Enabled { get; set; }
    }
}
