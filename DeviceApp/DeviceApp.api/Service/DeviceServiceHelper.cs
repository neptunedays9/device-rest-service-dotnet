﻿﻿
using System.Collections.Generic;
using System.Net;
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
    }
}