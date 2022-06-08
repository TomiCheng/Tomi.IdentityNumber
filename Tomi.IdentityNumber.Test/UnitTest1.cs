using System;
using Xunit;

namespace Tomi.IdentityNumber.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var instance = new TaiwanIdentityNumber();
            for (int i = 0; i < 100000; i++)
            {
                var id = instance.Generate();
                Assert.True(instance.Verify(id), id);
            }
        }
        [Fact]
        public void Test2()
        {
            var instance = new TaiwanResideNumberV1();
            for (int i = 0; i < 100000; i++)
            {
                var id = instance.Generate();
                Assert.True(instance.Verify(id), id);
            }
        }
        [Fact]
        public void Test3()
        {
            var instance = new TaiwanResideNumberV2();
            for (int i = 0; i < 100000; i++)
            {
                var id = instance.Generate();
                Assert.True(instance.Verify(id), id);
            }
        }
    }
}
