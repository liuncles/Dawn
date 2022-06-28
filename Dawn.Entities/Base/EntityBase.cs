namespace Dawn.Entities.Base
{
    /// <summary>
    /// 泛型主键Tkey
    /// 基类
    /// </summary>
    /// <typeparam name="Tkey"></typeparam>
    public class EntityTKeyBase<Tkey> where Tkey : IEquatable<Tkey>
    {
        [SugarColumn(IsPrimaryKey = true)]
        public Tkey Id { get; set; }
    }

    public class EntityBase : EntityTKeyBase<int>,ISoftDelete, ICreated, IModified
    {
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 创建者Id
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int? CreatedId { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? CreatedBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime? CreatedTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 修改者Id
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int? ModifiedId { get; set; }

        /// <summary>
        /// 修改者
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? ModifiedBy { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifiedTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 软删除
        /// </summary>
        public virtual void SoftDelete()
        {
            this.IsDeleted = true;
        }
    }
}
