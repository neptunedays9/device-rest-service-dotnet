﻿﻿namespace DeviceApp.util.lib.Error
{
    public class ErrorSet
    {

        public const string DuplicateItemFoundErrorId = "SRV_001";
        public const string DuplicateItemFoundErrorMessage = "Duplicate ID found, check the input";
        
        public const string ItemProcessingErrorId = "SRV_002";
        public const string ItemProcessingErrorMessage = "Backend update failed";

        public const string InvalidInputErrorId = "SRV_003";
        public const string InvalidInputErrorMessage = "Invalid input operation";

        public const string InvalidPurchaseItemErrorId = "SRV_004";
        public const string InvalidPurchaseItemErrorMessage = "Invalid input purchase item";

    }
}