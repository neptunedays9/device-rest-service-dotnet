
using DeviceApp.api.lib.Db;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DeviceApp.api.lib.Repository {

    public interface IModelRepository {
        Task<List<string>> GetAllModels() ;

    }

    public class ModelRepository : IModelRepository {

        private readonly IMongoDeviceContext _deviceContext;

        public ModelRepository(IMongoDeviceContext deviceContext) {
            _deviceContext = deviceContext;
        }

        public async Task<List<string>> GetAllModels() {
            List<string> modelList = new List<string>();
            
            // var cursor = await _deviceContext.models.FindAsync(item => item.Name == "iPhone 7");
            var cursor = await _deviceContext.models.FindAsync(FilterDefinition<ModelEntity>.Empty);

            await cursor.ForEachAsync(element => {
                modelList.Add(element.Name);
            });

            return modelList;
        }

    }
}