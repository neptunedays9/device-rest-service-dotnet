using System.Collections.Generic;
using System.Threading.Tasks;
using DeviceApp.api.lib.Db;

namespace DeviceApp.api.lib.Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        private List<Device> devices;

        DeviceRepository()
        {
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
            return 1;
        }

        public async Task<Device> Update(Device device)
        {
            return new Device();
        }
    }
}