﻿

using DeviceApp.util.lib.Common;
using DeviceApp.api.Model;

namespace DeviceApp.api.Service
{
    public class DiscountHelper
    {
        //Apply all the individual discount rules
        public static decimal ApplyIndividualDiscountRule(DeviceModel c)
        {
            decimal discount = 0;
            
            discount = ApplyYearDiscountIndividualRule(c);
            
            return discount;
        }

        //Apply all the total discount rules
        public static decimal ApplyTotalDiscountRule(int numDevices, decimal totalAmount)
        {
            decimal discount = 0;
            
            discount += ApplyItemDiscountTotalRule(numDevices, totalAmount);
            discount += ApplyCostDiscountTotalRule(numDevices, totalAmount);
            
            return discount;
        }
        
        public static decimal ApplyYearDiscountIndividualRule(DeviceModel c)
        {
            decimal discount = 0;
            if (c.Year < CommonConstants.INDIVIDUAL_RULE_YEAR_LIMIT)
            {
                discount = c.Price * CommonConstants.INDIVIDUAL_RULE_YEAR_DISCOUNT;
            }
            return (decimal)discount;
        }

        public static decimal ApplyItemDiscountTotalRule(int numDevices, decimal amount)
        {
            decimal discount = 0;
            if (numDevices > CommonConstants.TOTAL_RULE_ITEM_LIMIT)
            {
                discount = amount * CommonConstants.TOTAL_RULE_ITEM_DISCOUNT;
            }
            return discount;
        }

        public static decimal ApplyCostDiscountTotalRule(int numDevices, decimal amount)
        {
            decimal discount = 0;
            if (amount > CommonConstants.TOTAL_RULE_COST_DISCOUNT_LIMIT)
            {
                discount = amount * CommonConstants.TOTAL_RULE_COST_DISCOUNT;
            }
            return discount;
        }
        
    }
}
