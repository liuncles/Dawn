namespace Dawn.Repository.Mongo
{
    /// <summary>
    /// Mongo仓储接口
    /// 基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IMongoRepositoryBase<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task<TEntity> GetAsync(int Id);
        Task<List<TEntity>> GetListAsync();
    }
}
