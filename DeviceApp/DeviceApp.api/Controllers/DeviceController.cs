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
    [Route("api/[controller]")]
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
        public async Task<ResponseModel> ProcessDataAsync([FromBody] RequestModel input)
        {
            try
            {
                var responseModel = await _DeviceService.ProcessDataAsync(input.Devices.ToList(), 
                    input.operation);
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
