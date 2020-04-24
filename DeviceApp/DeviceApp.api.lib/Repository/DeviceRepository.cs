using System.Collections.Generic;
using System.Threading.Tasks;
using DeviceApp.api.lib.Db;

namespace DeviceApp.api.lib.Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly IMongoDeviceContext _deviceContext;
        private List<DeviceEntity> devices;

        public DeviceRepository()
        {
            devices = new List<DeviceEntity>();
            
            devices.Add(new DeviceEntity
            {
                Id = 123
            });
        }
        public async Task<List<DeviceEntity>> GetAllDevices()
        {
            return devices;
        }

        public async Task<int> Add(DeviceEntity device)
        {
            devices.Add(device);
            return devices.FindIndex(i => i.Id == device.Id);
        }

        public async Task<int> Update(DeviceEntity device)
        {
            int index = devices.FindIndex(i => i.Id == device.Id);
            devices[index] = device;
            return index;
        }
    }
}