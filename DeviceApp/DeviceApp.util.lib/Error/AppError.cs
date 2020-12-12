
    using System.Net;

    namespace DeviceApp.util.lib.Error
    {
            public class AppError {
                public HttpStatusCode apiStatusCode { get; set;}
                public string appErrorCode { get; set;}
                public string appErrorMessage { get; set;}
        }
        
    }
