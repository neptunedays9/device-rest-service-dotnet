
using DeviceApp.api.Model;
using DeviceApp.api.Service;
using Xunit;

namespace DeviceApp.api.Tests.Service
{
    public class DiscountHelperTest
    {
        [Theory]
        [InlineData(1, 500)]
        [InlineData(2, 100000)]
        public void ApplyTotalDiscountRule_NoDiscount(int numDevices, decimal amount)
        {
            decimal discount = DiscountHelper.ApplyTotalDiscountRule(numDevices, amount);
            Assert.Equal(0.0m, discount);
        }
        
        [Theory]
        [InlineData(3, 500, 15)]
        [InlineData(1, 200000, 10000.00)]
        [InlineData(3, 200000, 16000.00)]
        public void ApplyTotalDiscountRule_ValidDiscount(int numDevices, decimal amount, 
            decimal expectedDiscount)
        {
            decimal discount = DiscountHelper.ApplyTotalDiscountRule(numDevices, amount);
            Assert.Equal(expectedDiscount, discount);
        }
        
        [Theory]
        [InlineData(2000)]
        [InlineData(2001)]
        public void ApplyIndividualDiscountRule_NoDiscount(int year)
        {
            var deviceMock = new DeviceModel
            {
                Year = year
            };
            decimal discount = DiscountHelper.ApplyIndividualDiscountRule(deviceMock);
            Assert.Equal(0.0m, discount);
        }
        
        [Theory]
        [InlineData(1994, 500, 50)]
        [InlineData(1999, 8000, 800)]
        public void ApplyIndividualDiscountRule_ValidDiscount(int year, decimal price, 
            decimal expectedDiscount)
        {
            var deviceMock = new DeviceModel
            {
                Year = year,
                Price = price
            };
            decimal discount = DiscountHelper.ApplyIndividualDiscountRule(deviceMock);
            Assert.Equal(expectedDiscount, discount);
        }
        
        [Theory]
        [InlineData(1, 1000)]
        [InlineData(2, 20000)]
        public void ApplyItemDiscountTotalRule_NoDiscount(int numDevices, decimal amount)
        {
            decimal discount = DiscountHelper.ApplyItemDiscountTotalRule(numDevices, amount);
            Assert.Equal(0.0m, discount);
        }
        
        [Theory]
        [InlineData(3, 500, 15)]
        [InlineData(3, 200000, 6000.00)]
        public void ApplyItemDiscountTotalRule_ValidDiscount(int numDevices, decimal amount, decimal expectedDiscount)
        {
            decimal discount = DiscountHelper.ApplyItemDiscountTotalRule(numDevices, amount);
            Assert.Equal(expectedDiscount, discount);
        }
        
        [Theory]
        [InlineData(1, 200)]
        [InlineData(3, 200)]
        [InlineData(1, 99999.99)]
        [InlineData(1, 100000)]
        public void ApplyCostDiscountTotalRule_NoDiscount(int numDevices, decimal amount)
        {
            decimal discount = DiscountHelper.ApplyCostDiscountTotalRule(numDevices, amount);
            Assert.Equal(0.0m, discount);
        }
        
        [Theory]
        [InlineData(1, 100001, 5000.05)]
        [InlineData(3, 200000, 10000.00)]
        public void ApplyCostDiscountTotalRule_ValidDiscount(int numDevices, decimal amount, decimal expectedDiscount)
        {
            decimal discount = DiscountHelper.ApplyCostDiscountTotalRule(numDevices, amount);
            Assert.Equal(expectedDiscount, discount);
        }
    }
}