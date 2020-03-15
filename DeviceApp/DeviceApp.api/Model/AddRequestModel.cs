﻿﻿using System.ComponentModel.DataAnnotations;

namespace DeviceApp.api.Model
{
    public class AddRequestModel
    {
        [Required]
        public DeviceModel[] Devices { get; set; }
        
    }
}