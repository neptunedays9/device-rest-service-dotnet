using System.Collections.Generic;

namespace DeviceApp.api.Model {

    public class DeviceModelResponse {
        public string id { get; set; }
        public string deviceModel { get; set; }
        
    }

    public class DeviceModelListResponse {
        public List<DeviceModelResponse> deviceModels;
        
    }
}