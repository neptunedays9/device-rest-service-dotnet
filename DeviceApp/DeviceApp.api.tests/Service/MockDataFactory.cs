using System.Collections.Generic;
using DeviceApp.api.lib.Db;
using DeviceApp.api.Model;

namespace DeviceApp.Api.Tests.Service
{
    public class MockDataFactory
    {
        public static List<DeviceModel> GetListWithUniqueDeviceModels(int listLength)
        {
            var deviceModelList = new List<DeviceModel>();

            for (int i = 0; i < listLength; i++)
            {
                var deviceModel = new DeviceModel()
                {
                    Id = i,
                    Colour = "Red",
                    CountryManufactured = "A",
                    Model = "model",
                    Price = 100.0m,
                    Year = 2005
                };
                deviceModelList.Add(deviceModel);
            }
            return deviceModelList;
        }
        
        public static List<int> GetListWithDuplicateDeviceIds(int listLength)
        {
            var deviceModelList = new List<int>();

            for (int i = 0; i < listLength; i++)
            {
                deviceModelList.Add(i);
            }
            return deviceModelList;
        }

        public static List<DeviceModel> GetListWithDuplicateDeviceModels(int listLength)
        {
            var deviceModelList = new List<DeviceModel>();

            for (int i = 0; i < listLength; i++)
            {
                var deviceModel = new DeviceModel()
                {
                    Id = 1,
                    Colour = "Red",
                    CountryManufactured = "A",
                    Model = "model",
                    Price = 100.0m,
                    Year = 2005
                };
                deviceModelList.Add(deviceModel);
            }
            return deviceModelList;
        }

        public static List<Device> GetListWithUniqueDevices(int listLength)
        {
            var deviceList = new List<Device>();
            for (int i = 0; i < listLength; i++)
            {
                var device = new Device()
                {
                    Id = i,
                    Colour = "Red",
                    CountryManufactured = "A",
                    Model = "model",
                    Price = 100.0m,
                    Year = 2005
                };
                deviceList.Add(device);
            }

            return deviceList;
        }

    }
}