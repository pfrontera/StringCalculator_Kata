using System;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
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

        [Fact]
        public void TestWithEmptyString()
        {
            var expected = 0;
            var numbers = "";
            var result = StringCalculator.Add(numbers);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestWithOneNumber()
        {
            var expected = 2;
            var numbers = "2";
            var result = StringCalculator.Add(numbers);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestWithTwoNumbers()
        {
            var expected = 4;
            var numbers = "2,2";
            
            var result = StringCalculator.Add(numbers);
            
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestWithThreeNumbers()
        {
            var expected = 6;
            var numbers = "1,2,3";
            
            var result = StringCalculator.Add(numbers);
           
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestWithCommaSeparated()
        {
            var expected = 6;
            var numbers = "1\n2,3";
            
            var result = StringCalculator.Add(numbers);
            
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestSupportDelimiter()
        {
            var expected = ';';
            var numbers = "//;\n1;2";
            
            var result = StringCalculator.GetDefaultDelimiter(numbers);
            
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestFirstLineOptional()
        {
            var expected = '.';
            var numbers = "1.2.3.4";

            var result = StringCalculator.GetDefaultDelimiter(numbers);
            
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestWithNegativeNumbers()
        {
            var numbers = "a";
            Assert.Throws<Exception>(() => StringCalculator.Add(numbers));
        }
    }
}