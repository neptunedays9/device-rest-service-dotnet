﻿﻿using System;
using System.Net;

namespace DeviceApp.util.lib.Error
{
    public class AppException :ApplicationException
    {
        public HttpStatusCode ResponseCode { get; set;  }
        public string ErrorCode { get; set; }
        
        public string ErrorMessage { get; set; }

        public AppException(string errorCode)
        {
            var errorObj = ErrorMap.GetErrorDetails(errorCode);
            ResponseCode = errorObj.apiStatusCode;
            ErrorCode = errorCode;
            ErrorMessage = errorObj.appErrorMessage;
        }
    }
}