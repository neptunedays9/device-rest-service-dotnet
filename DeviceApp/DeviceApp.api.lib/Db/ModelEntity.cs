
using MongoDB.Bson;

namespace DeviceApp.api.lib.Db {

    public class ModelEntity {
        public ObjectId id { get; set; }
        
        public string Name { get; set; }
    }
}