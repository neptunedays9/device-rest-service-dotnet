﻿﻿using System.Collections.Generic;
using System.Threading.Tasks;
 using DeviceApp.api.Model;


 namespace DeviceApp.api.Service
{
    public interface IDeviceService
    {
        Task<ResponseModel> ProcessDataAsync(List<DeviceModel> Devices, 
            int operation);

        Task AddVehicleAsync(List<DeviceModel> Devices);
        Task<PurchaseModel> CalculateDiscountAsync(List<DeviceModel> Devices);

    }
}