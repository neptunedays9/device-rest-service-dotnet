﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DeviceApp.api.Model;


 namespace DeviceApp.api.Service
{
    public interface IDeviceService
    {
        Task<AddResponseModel> AddProductAsync(List<DeviceModel> Devices);
        
        Task<DiscountResponseModel> CalculateDiscountAsync(List<int> Devices);

    }
}