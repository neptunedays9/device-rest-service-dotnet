
using MongoDB.Driver;


namespace DeviceApp.api.lib.Db {

    
    public interface IMongoDeviceContext
    {
            IMongoCollection<DeviceEntity> devices { get; }

            IMongoCollection<ImageEntity> images { get; }

            IMongoCollection<ModelEntity> models { get; }

    }

    public class MongoDeviceContext : IMongoDeviceContext {

        private readonly IMongoDatabase _database;
        public MongoDeviceContext() {
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("deviceportaldata");
        }

        public IMongoDatabase Database => _database;
        public IMongoCollection<DeviceEntity> devices => _database.GetCollection<DeviceEntity>("Device");
        public IMongoCollection<ImageEntity> images => _database.GetCollection<ImageEntity>("Image");
       public IMongoCollection<ModelEntity> models => _database.GetCollection<ModelEntity>("Model");
    }
}