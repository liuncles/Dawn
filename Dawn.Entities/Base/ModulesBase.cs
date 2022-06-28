namespace Dawn.Entities.Base
{
    /// <summary>
    /// 模块表
    /// 基类
    /// </summary>
    /// <typeparam name="Tkey"></typeparam>
    public class ModulesBase<Tkey> : EntityBase where Tkey : IEquatable<Tkey>
    {
        /// <summary>
        /// 父Id（0表示无上一级）
        /// </summary>
        public Tkey? ParentId { get; set; }
    }
}
