using StringCalculator_Kata.Core;
using Xunit;

namespace StringCalculator_Kata.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test_HelloWorld()
        {
            var expected = "Hello World";
            var result = StringCalculator.HelloWorld();
            Assert.Equal(expected, result);
        }
    }
}