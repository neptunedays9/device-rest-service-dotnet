﻿﻿using System;
using System.Net;

namespace DeviceApp.util.lib.Error
{
    public class AppException :ApplicationException
    {
        public HttpStatusCode ResponseCode { get; set;  }
        public string ErrorCode { get; set; }
        
        public string ErrorMessage { get; set; }

        public AppException(HttpStatusCode responseCode,
            string errorCode, string errorMessage)
        {
            ResponseCode = responseCode;
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
    }
}