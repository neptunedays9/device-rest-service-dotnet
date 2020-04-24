using MongoDB.Bson;

namespace DeviceApp.api.lib.Db {

    public class ImageEntity {
        public ObjectId id {get; set; }
        public string name {get; set;}
        public byte[] data { get; set;}

        public string type {get; set;}

    }
}