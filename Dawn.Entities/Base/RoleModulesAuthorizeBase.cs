namespace Dawn.Entities.Base
{
    /// <summary>
    /// 角色模块与授权关联表
    /// 基类
    /// </summary>
    /// <typeparam name="Tkey"></typeparam>
    public class RoleModulesAuthorizeBase<Tkey> : EntityBase where Tkey : IEquatable<Tkey>
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public Tkey RoleId { get; set; }

        /// <summary>
        /// 模块Id
        /// </summary>
        public Tkey ModulesId { get; set; }

        /// <summary>
        /// 授权Id
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public Tkey AuthorizeId { get; set; }
    }
}
