using MongoDB.Bson;

using DeviceApp.api.lib.Db;

namespace DeviceApp.api.lib.Repository {

    public interface IImageRepository {
        ObjectId AddImage(ImageEntity img);

    }

    public class ImageRepository : IImageRepository{

        private readonly IMongoDeviceContext _deviceContext;

        public ImageRepository(IMongoDeviceContext deviceContext) {
            _deviceContext = deviceContext;
        }

        public ObjectId AddImage(ImageEntity img) {
            _deviceContext.images.InsertOne(img);
            return img.id;
        }

    }
}