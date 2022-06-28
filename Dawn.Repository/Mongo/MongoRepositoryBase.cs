using MongoDB.Bson;
using MongoDB.Driver;

namespace Dawn.Repository.Mongo
{
    /// <summary>
    /// Mongo仓储实现
    /// 基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class MongoRepositoryBase<TEntity> : IMongoRepositoryBase<TEntity> where TEntity : class, new()
    {
        private readonly MongoDbContext _context;

        public MongoRepositoryBase()
        {
            _context = new MongoDbContext();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Db.GetCollection<TEntity>(typeof(TEntity).Name)
               .InsertOneAsync(entity);
        }

        public async Task<TEntity> GetAsync(int Id)
        {
            var filter = Builders<TEntity>.Filter.Eq("Id", Id);

            return await _context.Db.GetCollection<TEntity>(typeof(TEntity).Name)
                .Find(filter)
                .FirstOrDefaultAsync();
        }

        public async Task<List<TEntity>> GetListAsync()
        {
            return await _context.Db.GetCollection<TEntity>(typeof(TEntity).Name)
                .Find(new BsonDocument())
                .ToListAsync();
        }
    }
}
