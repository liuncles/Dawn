using Dawn.Entities.System;

namespace Dawn.Entities.Base
{
    /// <summary>
    /// 授权表
    /// 基类
    /// </summary>
    /// <typeparam name="Tkey"></typeparam>
    public class AuthorizeBase<Tkey> : EntityBase where Tkey : IEquatable<Tkey>
    {
        /// <summary>
        /// 父Id（0表示无上一级）
        /// </summary>
        public Tkey? ParentId { get; set; }

        /// <summary>
        /// 模块Id
        /// </summary>
        public Tkey? ModulesId { get; set; }

        /// <summary>
        /// 父Id集合
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public List<Tkey>? PidArr { get; set; }

        /// <summary>
        /// 父名称集合
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public List<string> PnameArr { get; set; } = new List<string>();

        /// <summary>
        /// 父编号集合
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public List<string> PCodeArr { get; set; } = new List<string>();


        [SugarColumn(IsIgnore = true)]
        public string? MName { get; set; }

        [SugarColumn(IsIgnore = true)]
        public bool? hasChildren { get; set; } = true;

        [SugarColumn(IsIgnore = true)]
        public List<SysAuthorize> Children { get; set; } = new List<SysAuthorize>();

        [SugarColumn(IsIgnore = true)]
        public SysModules? Modules { get; set; }
    }
}
