using Dawn.Commons.DB;
using MongoDB.Driver;

namespace Dawn.Repository.Mongo
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database = null;

        public MongoDbContext()
        {
            var client = new MongoClient(AppSettings.App(new string[] { "Mongo", "ConnectionString" }));
            _database = client.GetDatabase(AppSettings.App(new string[] { "Mongo", "Database" }));
        }

        public IMongoDatabase Db
        {
            get { return _database; }
        }
    }
}
