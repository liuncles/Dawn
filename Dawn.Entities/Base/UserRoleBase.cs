namespace Dawn.Entities.Base
{
    /// <summary>
    /// 用户角色关联表
    /// 基类
    /// </summary>
    public class UserRoleBase<Tkey> : EntityBase where Tkey : IEquatable<Tkey>
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Tkey UserId { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public Tkey RoleId { get; set; }
    }
}
