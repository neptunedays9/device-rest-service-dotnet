
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DeviceApp.api.Common;
using DeviceApp.api.lib.Db;
using DeviceApp.api.lib.Repository;
using DeviceApp.api.Model;
using DeviceApp.api.Service;
using DeviceApp.Api.Tests.Service;
using Moq;
using Xunit;


namespace DeviceApp.Api.Devices.Tests.Service
{
    public class DeviceServiceTest
    {
        private List<Device> deviceListMock;
        private Mock<IDeviceRepository> deviceRepoMock = new Mock<IDeviceRepository>();
        
        [Fact]
        public void CalculateDiscount_NoDiscount()
        {
            int listLength = 2;
            var deviceService = CreateDeviceService(listLength);
            var discount = deviceService.CalculateDiscountAsync(
                MockDataFactory.GetListWithDuplicateDeviceIds(listLength));
            Assert.Equal(0.0m, discount.Result.discount);
        }
        
        [Fact]
        public void CalculateDiscount_DuplicateElement_Exception()
        {
            int listLength = 2;
            var deviceService = CreateDeviceService(listLength);
            Assert.ThrowsAsync<AppException>(async () =>
            {
                await deviceService.CalculateDiscountAsync(MockDataFactory.GetListWithDuplicateDeviceIds(listLength));
            });
        }

        [Fact]
        public async void AddVehicleAsync_AddNewDevice()
        {
            int listLength = 0;
            var deviceService = CreateDeviceService(listLength);
            
            listLength = 2;
            await deviceService.AddProductAsync(MockDataFactory.GetListWithUniqueDeviceModels(listLength));
            
            deviceRepoMock.Verify(mock => mock.Add(It.IsAny<Device>()), 
                Times.Exactly(listLength));
            
            deviceRepoMock.Verify(mock => mock.Update(It.IsAny<Device>()), 
                Times.Exactly(0));
        }

        [Fact]
        public async void AddVehicleAsync_UpdateExistingDevice()
        {
            int listLength = 2;
            var deviceService = CreateDeviceService(listLength);
            
            listLength = 2;
            await deviceService.AddProductAsync(MockDataFactory.GetListWithUniqueDeviceModels(listLength));
            
            deviceRepoMock.Verify(mock => mock.Add(It.IsAny<Device>()), 
                Times.Exactly(0));
            
            deviceRepoMock.Verify(mock => mock.Update(It.IsAny<Device>()), 
                Times.Exactly(listLength));
        }
        
        private DeviceService CreateDeviceService(int listLength)
        {
            deviceListMock = MockDataFactory.GetListWithUniqueDevices(listLength);
            var deviceMock = new Mock<Device>();
            
            deviceRepoMock.Setup(i => i.GetAllDevices()).Returns(Task.FromResult(deviceListMock));
            deviceRepoMock.Setup(x => x.Add(It.IsAny<Device>())).Returns(Task.FromResult(1));
            deviceRepoMock.Setup(x => x.Update(It.IsAny<Device>())).Returns(Task.FromResult(1));

            var config = new MapperConfiguration(cfg => cfg.CreateMap <DeviceModel, Device>());
            config.AssertConfigurationIsValid();
            IMapper mapper = config.CreateMapper();

            var deviceServiceHelperMock = new Mock<DeviceServiceHelper>(mapper);
        
            var deviceService = new DeviceService(deviceRepoMock.Object, 
                deviceServiceHelperMock.Object);
            return deviceService;
        }
        
    }
}