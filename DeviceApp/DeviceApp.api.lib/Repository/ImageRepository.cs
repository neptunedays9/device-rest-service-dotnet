using DeviceApp.api.lib.Db;

namespace DeviceApp.api.lib.Repository {

    public interface IImageRepository {
        void AddImage(Image img);

    }

    public class ImageRepository : IImageRepository{

        private readonly IMongoDeviceContext _deviceContext;

        public ImageRepository(IMongoDeviceContext deviceContext) {
            _deviceContext = deviceContext;
        }
        public void AddImage(Image img) {
            _deviceContext.images.InsertOne(img);
        }

    }
}