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
         * Performs preprocessing on the list
         * Checks add/update in repo
         * Calculate the discount
         */
        public async Task<ResponseModel> ProcessDataAsync(List<DeviceModel> Devices, int operation)
        {
            ResponseModel res = new ResponseModel();
            if(operation == (int) CommonConstants.operation.operationAdd)
            {
                await AddProductAsync(Devices);
                res.operationStatus = CommonConstants.operationSuccess;
            }
            else if(operation == (int) CommonConstants.operation.operationCalculate)
            {
                var purchaseModel = await CalculateDiscountAsync(Devices);
                res.operationStatus = CommonConstants.operationSuccess;
                res.purchase = purchaseModel;
            }
            else
            {
                throw new AppException(HttpStatusCode.Forbidden,
                    ErrorSet.InvalidInputErrorId,
                    ErrorSet.InvalidInputErrorMessage);

            }
            return res;
        }


        /*
         * Add / Update the elements
         */
        public async Task AddProductAsync(List<DeviceModel> Devices)
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
                }
                catch (Exception e)
                {
                    throw new AppException(HttpStatusCode.InternalServerError,
                        ErrorSet.ItemProcessingErrorId, ErrorSet.ItemProcessingErrorMessage);
                }

            }
        }

        /*
         * Rules categorised into total rule and individual rule
         * All the discount rules will be applied cumulative
         * Individual rules is applied on each item
         * Total rules applied on the summary
         */
        public async Task<PurchaseModel> CalculateDiscountAsync(List<DeviceModel> Devices)
        {
            try 
            {
                //perform preprocessing on the input list
                if (await ValidateProcessListAsync(Devices))
                {
                    decimal discount = 0;
                    decimal amount = 0;
                    int numberDevices = Devices.Count;

                    Devices.ForEach(c =>
                    {
                        discount += DiscountHelper.ApplyIndividualDiscountRule(c);
                        amount += c.Price;
                    });

                    discount += DiscountHelper.ApplyTotalDiscountRule(numberDevices, amount);
                    return new PurchaseModel()
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

        /*
         * Confirm that all the elements in purchase list are present in repo
         * Take the repo for calculation of discount
         */
        private async Task<bool> ValidateProcessListAsync(List<DeviceModel> Devices)
        {
            bool result = true;
            var allDevices = await _DeviceRepo.GetAllDevices();
            
            Devices.ForEach(Device =>
            {
                //check if the Device exist in the repo
                var DeviceSearch = allDevices.Find(c => c.Id == Device.Id);
                if ( DeviceSearch == null)
                {
                    result = false;
                }
                else
                {
                    //get the data from the repo for calculations
                    Device.Price = DeviceSearch.Price;
                    Device.Year = DeviceSearch.Year;
                }
                
                //check if duplicate items in the purchase list
                var res = Devices.FindAll(i => i.Id == Device.Id);
                if (res.Count > 1)
                {
                    result = false;
                }

            });
            return result;
        }

    }
}