﻿using System;
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
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        public ImageResponseModel AddImage(ImageRequestModel image) {
            var imgId =_imageService.AddImage(image.name, image.type, image.data);
            var imgResponse = new ImageResponseModel {
                imageId = imgId
            };
            return imgResponse;
        }
    }
}
