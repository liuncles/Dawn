namespace Dawn.Entities.Base
{
    /// <summary>
    /// 组织机构
    /// 基类
    /// </summary>
    /// <typeparam name="Tkey"></typeparam>
    public class OrganizationBase<Tkey> : EntityBase where Tkey : IEquatable<Tkey>
    {
        /// <summary>
        /// 父Id（0表示无上一级）
        /// </summary>
        public Tkey ParentId { get; set; }

        /// <summary>
        /// 父Id集合
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public List<Tkey> PidArr { get; set; }
    }
}
