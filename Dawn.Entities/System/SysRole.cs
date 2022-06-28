namespace Dawn.Entities.System
{
    /// <summary>
    /// 角色表
    /// </summary>
    [SugarTable("sys_role")]
    public class SysRole : EntityBase
    {
        public SysRole()
        {
            Sorts = 1;
            IsDeleted = false;
            CreatedTime = DateTime.Now;
            ModifiedTime = DateTime.Now;
        }

        public SysRole(string name)
        {
            Name = name;
            Description = "";
            Sorts = 1;
            Enabled = true;
            CreatedTime = DateTime.Now;
            ModifiedTime = DateTime.Now;
        }

        /// <summary>
        /// 角色名称
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? Name { get; set; }

        /// <summary>
        ///描述
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? Description { get; set; }

        /// <summary>
        ///排序
        /// </summary>
        public int? Sorts { get; set; }

        /// <summary>
        /// 自定义权限的机构ids
        /// </summary>
        [SugarColumn(Length = 200, IsNullable = true)]
        public string? Oids { get; set; }

        /// <summary>
        /// 权限范围
        /// -1 无任何权限；1 自定义权限；2 本机构；3 本机构及以下；4 仅自己；9 全部；
        /// </summary>
        public int? AuthorityScope { get; set; } = -1;

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool Enabled { get; set; }
    }
}
