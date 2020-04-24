﻿﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using DeviceApp.api.Common;
using DeviceApp.api.lib.Repository;
using DeviceApp.api.Model;

 namespace DeviceApp.api.Service
{
    public class DeviceService : IDeviceService
    {
        private IDeviceRepository _DeviceRepo;
        private DeviceServiceHelper _DeviceServiceHelper;
        
        public DeviceService(IDeviceRepository DeviceRepo, DeviceServiceHelper DeviceServiceHelper)
        {
            _DeviceRepo = DeviceRepo;
            _DeviceServiceHelper = DeviceServiceHelper;
        }

        /*
         * Add / Update the elements
         */
        public async Task<AddResponseModel> AddProductAsync(List<DeviceModel> Devices)
        { 
            //perform preprocessing on the input list
            var DeviceObjList = _DeviceServiceHelper.PreProcessList(Devices);
            
            if (DeviceObjList != null)
            {
                try
                {
                    DeviceObjList.ForEach(async Device =>
                    {
                        var allDevices = await _DeviceRepo.GetAllDevices();
                        var DeviceObj = allDevices.Find(i => i.Id == Device.Id);
                        if (DeviceObj != null)
                        {
                            await _DeviceRepo.Update(Device);
                        }
                        else
                        {
                            int a = await _DeviceRepo.Add(Device);
                        }
                    });
                    
                    return new AddResponseModel
                    {
                        operationStatus = CommonConstants.operationSuccess
                    };

                }
                catch (Exception e)
                {
                    throw new AppException(HttpStatusCode.InternalServerError,
                        ErrorSet.ItemProcessingErrorId, ErrorSet.ItemProcessingErrorMessage);
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
                var repoDevices = await _DeviceServiceHelper.ValidateProcessListAsync(Devices, await _DeviceRepo.GetAllDevices());
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
                    throw new AppException(HttpStatusCode.Forbidden,
                        ErrorSet.InvalidPurchaseItemErrorId,
                        ErrorSet.InvalidPurchaseItemErrorMessage);
                }
            }
            catch (AppException e)
            {
                throw e;
            }
        }

    }
}