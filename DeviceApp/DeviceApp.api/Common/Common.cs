﻿﻿namespace DeviceApp.api.Common
{
    public class CommonConstants
    {
        public static decimal TOTAL_RULE_COST_DISCOUNT_LIMIT = 100000m;
        public static decimal TOTAL_RULE_COST_DISCOUNT = 0.05m;     
            
        public static int TOTAL_RULE_ITEM_LIMIT = 2;
        public static decimal TOTAL_RULE_ITEM_DISCOUNT = 0.03m;     

        public static int INDIVIDUAL_RULE_YEAR_LIMIT = 2000;
        public static decimal INDIVIDUAL_RULE_YEAR_DISCOUNT = 0.1m;
        
        //operationTypes
        public enum operation
        {
            operationAdd = 1,
            operationCalculate
        }
        
        //operation status
        public static string operationSuccess = "Success"; 

    }
}