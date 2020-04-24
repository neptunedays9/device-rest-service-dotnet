using DeviceApp.api.lib.Db;
using DeviceApp.api.lib.Repository;
using DeviceApp.api.Model;

namespace DeviceApp.api.Service {

    public interface IImageService
    {
        string AddImage(string name, string type, byte[] data);
    }
    public class ImageService : IImageService{
        private readonly IImageRepository _imageRepo;

        public ImageService(IImageRepository imageRepo) {
            _imageRepo = imageRepo;
        }

        public string AddImage(string imgName, string imgType, byte[] imgData) {

            ImageEntity imageEntity = new ImageEntity {
                name = imgName,
                data = imgData,
                type = imgType
            };

            var imgId = _imageRepo.AddImage(imageEntity);
            return imgId.ToString();

        }

    }
}