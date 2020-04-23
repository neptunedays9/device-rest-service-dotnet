using System.Collections.Generic;
using System.Threading.Tasks;
using DeviceApp.api.lib.Db;

namespace DeviceApp.api.lib.Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly IMongoDeviceContext _deviceContext;
        private List<Device> devices;

        public DeviceRepository()
        {
            devices = new List<Device>();
            
            devices.Add(new Device
            {
                Id = 123
            });
        }
        public async Task<List<Device>> GetAllDevices()
        {
            return devices;
        }

        public async Task<int> Add(Device device)
        {
            devices.Add(device);
            return devices.FindIndex(i => i.Id == device.Id);
        }

        public async Task<int> Update(Device device)
        {
            int index = devices.FindIndex(i => i.Id == device.Id);
            devices[index] = device;
            return index;
        }
    }
}