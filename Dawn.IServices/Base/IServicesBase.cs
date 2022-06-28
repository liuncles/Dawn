namespace Dawn.IServices.Base
{
    /// <summary>
    /// 服务接口
    /// 基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IServicesBase<TEntity> where TEntity : class
    {
        #region 实体  增、删、改
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> AddAsync(TEntity entity);

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="listEntity"></param>
        /// <returns></returns>
        Task<int> AddAsync(List<TEntity> listEntity);

        /// <summary>
        /// 根据id，删除指定实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// 根据ids，批量删除实体
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<bool> DeleteByIdsAsync(object[] ids);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(TEntity entity);

        /// <summary>
        /// 批量更新实体
        /// </summary>
        /// <param name="listEntity"></param>
        /// <returns></returns>
        Task<int> UpdateByListAsync(List<TEntity> listEntity);
        #endregion

        #region 实体 查询
        /// <summary>
        /// 根据id获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> FindAsync(object objId);

        /// <summary>
        /// 根据条件获取实体
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> func);

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> QueryAsync();

        /// <summary>
        /// 根据条件查询数据集
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func);

        /// <summary>
        /// 根据条件查询数据集，并排序
        /// </summary>
        /// <param name="func"></param>
        /// <param name="orderByFunc"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func, Expression<Func<TEntity, object>> orderByFunc, bool isAsc = true);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        Task<List<TEntity>> QueryPageAsync(int page, int size, RefAsync<int> total);

        /// <summary>
        /// 自定义条件分页查询
        /// </summary>
        /// <param name="func"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        Task<List<TEntity>> QueryPageAsync(Expression<Func<TEntity, bool>> func, int page, int size, RefAsync<int> total);
        #endregion
    }
}
