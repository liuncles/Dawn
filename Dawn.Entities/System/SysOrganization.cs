namespace Dawn.Entities.System
{
    /// <summary>
    /// 组织机构表
    /// </summary>
    [SugarTable("sys_organization")]
    public class SysOrganization : OrganizationBase<int>
    {
        /// <summary>
        /// 编码
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? Code { get; set; }

        /// <summary>
        /// 机构名称
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? Name { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? Leader { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? Email { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? Address { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? Description { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int? Sorts { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 是否包括子节点
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public bool HasChildren { get; set; } = true;
    }
}
