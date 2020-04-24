using System.Collections.Generic;
using AutoMapper;
using DeviceApp.api.Common;
using DeviceApp.api.lib.Db;
using DeviceApp.api.Model;
using DeviceApp.api.Service;
using Xunit;

namespace DeviceApp.Api.Tests.Service
{
    public class DeviceServiceHelperTest
    {
        [Fact]
        public void PreProcessList_Duplicate()
        {
            var deviceModelList = new List<DeviceModel>();
            var deviceModelMock = new DeviceModel
            {
                Id = 123
            };
            deviceModelList.Add(deviceModelMock);
            deviceModelList.Add(deviceModelMock);
           
            var config = new MapperConfiguration(cfg => cfg.CreateMap <DeviceModel, DeviceEntity>());
            config.AssertConfigurationIsValid();
            
            IMapper mapper = config.CreateMapper();
            
            DeviceServiceHelper _deviceServiceHelper = new DeviceServiceHelper(mapper);
            Assert.Throws<AppException>(() => 
                    _deviceServiceHelper.PreProcessList(deviceModelList));
        }
        
        [Fact]
        public void PreProcessList_AllUnique()
        {
            var deviceModelList = new List<DeviceModel>();
            var deviceModelMock = new DeviceModel
            {
                Id = 123
            };
            deviceModelList.Add(deviceModelMock);
            
            deviceModelMock = new DeviceModel
            {
                Id = 234
            };
            deviceModelList.Add(deviceModelMock);
           
            var config = new MapperConfiguration(cfg => cfg.CreateMap <DeviceModel, DeviceEntity>());
            config.AssertConfigurationIsValid();
            
            IMapper mapper = config.CreateMapper();
            
            DeviceServiceHelper _deviceServiceHelper = new DeviceServiceHelper(mapper);
            var deviceList = _deviceServiceHelper.PreProcessList(deviceModelList);
            Assert.Equal(deviceModelList.Count, deviceList.Count);
        }
    }
}