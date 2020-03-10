﻿﻿namespace DeviceApp.api.Model
{
    public class PurchaseModel
    {
        public decimal totalAmountBeforeDiscount { get; set; }

        public decimal discount { get; set; }
    }
    
    public class ResponseModel
    {
        public string operationStatus { get; set; }
        
        public PurchaseModel purchase { get; set; }

    }
}