﻿using System;

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
// using System.Threading.Tasks;
using DeviceApp.api.lib.Repository;
using DeviceApp.api.Model;
using DeviceApp.util.lib.Common;
using DeviceApp.util.lib.Error;

 namespace DeviceApp.api.Service
{
    public class DeviceService : IDeviceService
    {
        private IDeviceRepository _deviceRepo;
        private DeviceServiceHelper _deviceServiceHelper;

        private IModelRepository _modelRepo;
        
        public DeviceService(IDeviceRepository deviceRepo, 
            DeviceServiceHelper deviceServiceHelper,
            IModelRepository modelRepo)
        {
            _deviceRepo = deviceRepo;
            _deviceServiceHelper = deviceServiceHelper;
            _modelRepo = modelRepo;
        }

        /*
         * Add / Update the elements
         */
        public async Task<AddResponseModel> AddProductAsync(List<DeviceModel> Devices)
        { 
            //perform preprocessing on the input list
            var DeviceObjList = _deviceServiceHelper.PreProcessList(Devices);
            
            if (DeviceObjList != null)
            {
                try
                {
                    DeviceObjList.ForEach(async Device =>
                    {
                        var allDevices = await _deviceRepo.GetAllDevices();
                        var DeviceObj = allDevices.Find(i => i.Id == Device.Id);
                        if (DeviceObj != null)
                        {
                            await _deviceRepo.Update(Device);
                        }
                        else
                        {
                            int a = await _deviceRepo.Add(Device);
                        }
                    });
                    
                    return new AddResponseModel
                    {
                        operationStatus = CommonConstants.operationSuccess
                    };

                }
                catch (Exception e)
                {
                    throw new AppException(ErrorSet.DuplicateItemFoundErrorId);
                }
            }
            return null;
        }

        /*
         * Rules categorised into total rule and individual rule
         * All the discount rules will be applied cumulative
         * Individual rules is applied on each item
         * Total rules applied on the summary
         */
        public async Task<DiscountResponseModel> CalculateDiscountAsync(List<int> Devices)
        {
            try
            {
                var repoDevices = await _deviceServiceHelper.ValidateProcessListAsync(Devices, await _deviceRepo.GetAllDevices());
                //perform preprocessing on the input list
                if (repoDevices != null)
                {
                    decimal discount = 0;
                    decimal amount = 0;
                    int numberDevices = Devices.Count;

                    repoDevices.ForEach(c =>
                    {
                        discount += DiscountHelper.ApplyIndividualDiscountRule(c);
                        amount += c.Price;
                    });

                    discount += DiscountHelper.ApplyTotalDiscountRule(numberDevices, amount);
                    return new DiscountResponseModel()
                    {
                        discount = discount,
                        totalAmountBeforeDiscount = amount
                    };
                }
                else
                {
                    throw new AppException(ErrorSet.InvalidPurchaseItemErrorId);
                }
            }
            catch (AppException e)
            {
                throw e;
            }
        }

        public async Task<List<string>> GetAllModels() {
            return await _modelRepo.GetAllModels();
        }

    }
}