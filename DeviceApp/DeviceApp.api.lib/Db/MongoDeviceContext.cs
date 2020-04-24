
using MongoDB.Bson;
using MongoDB.Driver;
// using MongoDB.Driver.GridFS;
using System;
using System.Threading.Tasks;

namespace DeviceApp.api.lib.Db {

    
    public interface IMongoDeviceContext
    {
            IMongoCollection<DeviceEntity> devices { get; }

            IMongoCollection<ImageEntity> images { get; }

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

    }
}