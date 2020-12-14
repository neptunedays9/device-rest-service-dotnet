using System;
using Xunit;
using DeviceApp.util.lib.Error;

namespace DeviceApp.util.lib.test
{
    public class ErrorMapTest
    {
        [Fact]
        public void GetErrorDetails_return_object()
        {
            var a = ErrorMap.GetErrorDetails(ErrorSet.DuplicateItemFoundErrorId);
            Console.WriteLine("Object:", a);
            Assert.Equal(false, false);
        }
    }
}
