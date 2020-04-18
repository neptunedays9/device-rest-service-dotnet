﻿﻿using System;
using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using DeviceApp.api.Model;
 using DeviceApp.api.Service;
 using Microsoft.AspNetCore.Authorization;
 using Microsoft.AspNetCore.Mvc;

 namespace DeviceApp.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _DeviceService;
        public DeviceController(IDeviceService DeviceService)
        {
            _DeviceService = DeviceService;
        }
        // GET api/Devices
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            return new string[] { "success" };
        }

        // GET api/Devices
        [HttpGet("header")]
        public HeaderResponseModel GetDeviceHeader()
        {
            HeaderResponseModel response = new HeaderResponseModel();
            
            var objList = new List<Header>();

            objList.Add(new Header {
                id = "1",
                description = "d"
                }
            );

            objList.Add(new Header {
                id = "2",
                description = "dd"
                }
            );

            response.devices = objList;
            
            return response;
        }

        /*
         * Endpoint <server>/api/Device
         * REST endpoint to add/update/calculate-discount
         * Sample JSON
         * {
         *    "Devices": [{],{]],
         *    "operation" : 1
         * }
         * operation 1(add/update) 2(purchase)
         */
        [HttpPost]
        [Authorize]
        public async Task<AddResponseModel> AddDataAsync([FromBody] AddRequestModel input)
        {
            try
            {
                var responseModel = await _DeviceService.AddProductAsync(input.Devices.ToList());
                if (responseModel != null)
                {
                    return responseModel;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return null;
        }

        /*
         * Endpoint <server>/api/Device
         * REST endpoint to add/update/calculate-discount
         * Sample JSON
         * {
         *    "Devices": [{],{]],
         *    "operation" : 1
         * }
         * operation 1(add/update) 2(purchase)
         */
        [HttpPost("/discount")]
        [Authorize]
        public async Task<DiscountResponseModel> CalculateDiscountAsync([FromBody] DiscountRequestModel input)
        {
            try
            {
                var responseModel = await _DeviceService.CalculateDiscountAsync(input.Devices.ToList());
                if (responseModel != null)
                {
                    return responseModel;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return null;
        }
    }
}
