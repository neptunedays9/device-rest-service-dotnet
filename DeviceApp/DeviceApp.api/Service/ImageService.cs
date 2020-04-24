using DeviceApp.api.lib.Db;
using DeviceApp.api.lib.Repository;

namespace DeviceApp.api.Service {

    public interface IImageService
    {
        void AddImage(string name, string type, byte[] data);
    }
    public class ImageService : IImageService{
        private readonly IImageRepository _imageRepo;

        public ImageService(IImageRepository imageRepo) {
            _imageRepo = imageRepo;
        }

        public void AddImage(string imgName, string imgType, byte[] imgData) {

            ImageEntity imageEntity = new ImageEntity {
                name = imgName,
                data = imgData,
                type = imgType
            };

            _imageRepo.AddImage(imageEntity);
        }

    }
}