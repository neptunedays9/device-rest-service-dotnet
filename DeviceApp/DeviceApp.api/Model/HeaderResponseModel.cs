
using System.Collections.Generic;

namespace DeviceApp.api.Model
{
    public class Header {
        public string id {get; set;}
        public string description { get; set;}
    }

    public class HeaderResponseModel {
        public List <Header> objHeaders;
        
    }
}