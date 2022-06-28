namespace Dawn.Services.Base
{
    /// <summary>
    /// 服务
    /// 基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class ServicesBase<TEntity> : IServicesBase<TEntity> where TEntity : class, new()
    {
        protected IRepositoryBase<TEntity> _iRepositoryBase;

        #region 实体 增、删、改
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync(TEntity entity)
        {
            return await _iRepositoryBase.AddAsync(entity);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="listEntity"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(List<TEntity> listEntity)
        {
            return await _iRepositoryBase.AddAsync(listEntity);
        }

        /// <summary>
        /// 根据id，删除指定实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            return await _iRepositoryBase.DeleteAsync(id);
        }

        /// <summary>
        /// 根据ids，批量删除实体
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<bool> DeleteByIdsAsync(object[] ids)
        {
            return await _iRepositoryBase.DeleteByIdsAsync(ids);
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(TEntity entity)
        {
            return await _iRepositoryBase.UpdateAsync(entity);
        }

        /// <summary>
        /// 批量更新实体
        /// </summary>
        /// <param name="listEntity"></param>
        /// <returns></returns>
        public async Task<int> UpdateByListAsync(List<TEntity> listEntity)
        {
            return await _iRepositoryBase.UpdateByListAsync(listEntity);
        }
        #endregion

        #region 实体 查询
        /// <summary>
        /// 根据id获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> FindAsync(object objId)
        {
            return await _iRepositoryBase.FindAsync(objId);
        }

        /// <summary>
        /// 根据条件获取实体
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> func)
        {
            return await _iRepositoryBase.FindAsync(func);
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<TEntity>> QueryAsync()
        {
            return await _iRepositoryBase.QueryAsync();
        }

        /// <summary>
        /// 根据条件查询数据集
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func)
        {
            return await _iRepositoryBase.QueryAsync(func);
        }

        /// <summary>
        /// 根据条件查询数据集，并排序
        /// </summary>
        /// <param name="func"></param>
        /// <param name="orderByFunc"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func, Expression<Func<TEntity, object>> orderByFunc, bool isAsc = true)
        {
            return await _iRepositoryBase.QueryAsync(func, orderByFunc, isAsc);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> QueryPageAsync(int page, int size, RefAsync<int> total)
        {
            return await _iRepositoryBase.QueryPageAsync(page, size, total);
        }

        /// <summary>
        /// 自定义条件分页查询
        /// </summary>
        /// <param name="func"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> QueryPageAsync(Expression<Func<TEntity, bool>> func, int page, int size, RefAsync<int> total)
        {
            return await _iRepositoryBase.QueryPageAsync(func, page, size, total);
        }
        #endregion
    }
}
