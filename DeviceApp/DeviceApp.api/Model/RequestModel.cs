﻿﻿using System.ComponentModel.DataAnnotations;

namespace DeviceApp.api.Model
{
    public class RequestModel
    {
        [Required]
        public DeviceModel[] Devices { get; set; }
        
        [Required]
        [Range(1,2)]
        public int operation { get; set; }
        
    }
}