﻿﻿
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using DeviceApp.api.Common;
using DeviceApp.api.lib.Db;
using DeviceApp.api.Model;

namespace DeviceApp.api.Service
{
    public class DeviceServiceHelper
    {
        private IMapper _mapper;

        public DeviceServiceHelper(IMapper mapper)
        {
            _mapper = mapper;
        }
        /*
         * Check if duplicate entry found in the list
         * AutoTransform the model to the Device objects
         */
        public List<Device> PreProcessList(List<DeviceModel> Devices)
        {
            var DeviceObjList = new List<Device>();
            Devices.ForEach(c =>
            {
                var res = Devices.FindAll(i => i.Id == c.Id);
                if (res.Count > 1)
                {
                    throw new AppException(HttpStatusCode.Forbidden,
                        ErrorSet.DuplicateItemFoundErrorId,
                        ErrorSet.DuplicateItemFoundErrorMessage);
                }
                DeviceObjList.Add(_mapper.Map<DeviceModel, Device>(c));

            });

            return DeviceObjList;
        }
        
        /*
         * Confirm that all the elements in purchase list are present in repo
         * Take the repo for calculation of discount
         */
        public async Task<List<DeviceModel>> ValidateProcessListAsync(List<int> requestDevices, List<Device> allDevices)
        {
            bool result = true;
            var devices = new List<DeviceModel>();

            requestDevices.ForEach(deviceId =>
            {
                //check if the Device exist in the repo
                var deviceSearch = allDevices.Find(c => c.Id == deviceId);
                if ( deviceSearch == null)
                {
                    return;
                }
                else
                {
                    devices.Add(new DeviceModel
                    {
                        Id = deviceId,
                        //get the data from the repo for calculations
                        Price = deviceSearch.Price,
                        Year = deviceSearch.Year
                    });
                }
                
                //check if duplicate items in the input purchase list
                var res = requestDevices.FindAll(i => i == deviceId);
                if (res.Count > 1)
                {
                    return;
                }

            });
            return devices;
        }
    }
}