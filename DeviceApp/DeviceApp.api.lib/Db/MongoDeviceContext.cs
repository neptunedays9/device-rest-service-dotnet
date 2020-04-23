
using MongoDB.Bson;
using MongoDB.Driver;
// using MongoDB.Driver.GridFS;
using System;
using System.Threading.Tasks;

namespace DeviceApp.api.lib.Db {

    
    public interface IMongoDeviceContext
    {
            IMongoCollection<Device> devices { get; }

            IMongoCollection<Image> images { get; }

    }

    public class MongoDeviceContext : IMongoDeviceContext {

        private readonly IMongoDatabase _database;
        public MongoDeviceContext() {
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("deviceportaldata");
        }

        public IMongoDatabase Database => _database;
        public IMongoCollection<Device> devices => _database.GetCollection<Device>("Devices");
        public IMongoCollection<Image> images => _database.GetCollection<Image>("Images");

    }
}