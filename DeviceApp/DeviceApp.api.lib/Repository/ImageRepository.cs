using MongoDB.Bson;

using DeviceApp.api.lib.Db;

namespace DeviceApp.api.lib.Repository {

    public interface IImageRepository {
        void AddImage(ImageEntity img);

    }

    public class ImageRepository : IImageRepository{

        private readonly IMongoDeviceContext _deviceContext;

        public ImageRepository(IMongoDeviceContext deviceContext) {
            _deviceContext = deviceContext;
        }

        public void AddImage(ImageEntity img) {
            _deviceContext.images.InsertOne(img);
        }

    }
}