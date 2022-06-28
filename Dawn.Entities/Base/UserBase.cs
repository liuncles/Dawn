namespace Dawn.Entities.Base
{
    /// <summary>
    /// 用户关联表
    /// 基类
    /// </summary>
    /// <typeparam name="Tkey"></typeparam>
    public class UserBase<Tkey> : EntityBase where Tkey : IEquatable<Tkey>
    {
        /// <summary>
        /// 角色Id集合
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public List<Tkey> RoleIds { get; set; }

        /// <summary>
        /// 角色名称集合
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public List<string> RoleNames { get; set; }
    }
}
