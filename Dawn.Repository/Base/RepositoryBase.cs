namespace Dawn.Repository.Base
{
    /// <summary>
    /// 仓储实现
    /// 基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class RepositoryBase<TEntity> : SimpleClient<TEntity>, IRepositoryBase<TEntity> where TEntity : class, new()
    {
        private readonly IUnitOfWork _unitOfWork;

        public RepositoryBase(ISqlSugarClient context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
            base.Context = unitOfWork.GetDbClient();
            base.Context = DbScoped.SugarScope;
        }

        #region 实体增、删、改
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync(TEntity entity)
        {
            return await base.InsertAsync(entity);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="listEntity"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(List<TEntity> listEntity)
        {
            return await base.AsInsertable(listEntity.ToArray()).ExecuteCommandAsync();
        }

        /// <summary>
        /// 根据id，删除指定实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            return await base.DeleteByIdAsync(id);
        }

        /// <summary>
        /// 根据ids，批量删除实体
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<bool> DeleteIdsAsync(object[] ids)
        {
            return await base.DeleteByIdsAsync(ids);
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(TEntity entity)
        {
            return await base.UpdateAsync(entity);
        }

        /// <summary>
        /// 批量更新实体
        /// </summary>
        /// <param name="listEntity"></param>
        /// <returns></returns>
        public async Task<int> UpdateByListAsync(List<TEntity> listEntity)
        {
            return await base.AsUpdateable(listEntity.ToArray()).ExecuteCommandAsync();
        }
        #endregion

        #region 查询
        /// <summary>
        /// 根据id获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> FindAsync(object objId)
        {
            return await base.GetByIdAsync(objId);
        }

        /// <summary>
        /// 根据条件获取实体
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> func)
        {
            return await base.GetSingleAsync(func);
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<TEntity>> QueryAsync()
        {
            return await base.GetListAsync();
        }

        /// <summary>
        /// 根据条件查询数据集
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func)
        {
            return await base.GetListAsync(func);
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
            return await base.Context.Queryable<TEntity>()
                .OrderByIF(orderByFunc != null, orderByFunc, isAsc ? OrderByType.Asc : OrderByType.Desc)
                .WhereIF(func != null, func).ToListAsync();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<TEntity>> QueryPageAsync(int page, int size, RefAsync<int> total)
        {
            return await base.Context.Queryable<TEntity>()
                .ToPageListAsync(page, size, total);
        }

        /// <summary>
        /// 自定义条件分页查询
        /// </summary>
        /// <param name="func"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<TEntity>> QueryPageAsync(Expression<Func<TEntity, bool>> func, int page, int size, RefAsync<int> total)
        {
            return await base.Context.Queryable<TEntity>()
                .Where(func)
                .ToPageListAsync(page, size, total);
        }

        /// <summary>
        /// 查询-多表查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="joinExpression"></param>
        /// <param name="selectExpression"></param>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<TResult>> QueryManyAsync<T, T2, T3, TResult>(
            Expression<Func<T, T2, T3, object[]>> joinExpression,
            Expression<Func<T, T2, T3, TResult>> selectExpression,
            Expression<Func<T, T2, T3, bool>> whereLambda = null) where T : class, new()
        {
            if (whereLambda == null)
            {
                return await base.Context.Queryable(joinExpression).Select(selectExpression).ToListAsync();
            }
            return await base.Context.Queryable(joinExpression).Where(whereLambda).Select(selectExpression).ToListAsync();
        }
        #endregion
    }
}
