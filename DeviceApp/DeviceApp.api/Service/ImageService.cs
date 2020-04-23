using DeviceApp.api.lib.Db;
using DeviceApp.api.lib.Repository;

namespace DeviceApp.api.Service {

    public interface IImageService
    {
        void AddImage(string name, string type, string uri);
    }
    public class ImageService : IImageService{
        private readonly IImageRepository _imageRepo;

        public ImageService(IImageRepository imageRepo) {
            _imageRepo = imageRepo;
        }

        public void AddImage(string name, string type, string uri) {
            Image img = new Image {
            };

            _imageRepo.AddImage(img);
        }

    }
}