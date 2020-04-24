using System.Collections.Generic;
using System.Data;
using System.Net.Sockets;
using System.Threading.Tasks;
using DeviceApp.api.lib.Db;

namespace DeviceApp.api.lib.Repository
{
    public interface IDeviceRepository
    {
        Task<List<DeviceEntity>> GetAllDevices();
        Task<int> Add(DeviceEntity device);
        Task<int> Update(DeviceEntity device);
    }
}