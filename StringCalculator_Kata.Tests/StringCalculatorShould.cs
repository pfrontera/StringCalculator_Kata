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
            var numbers = "1,2,3";
            
            var result = StringCalculator.Add(numbers);
            
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void TestSupportingNewLines()
        {
            var expected = 6;
            var numbers = "1\n2,3";
            
            var result = StringCalculator.Add(numbers);
            
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestContainsDefaultDelimiter()
        {
            var numbers = "//;\n1;2";
            var expected = true;
            
            var result = StringCalculator.ContainsDefaultDelimiter(numbers);
            
            Assert.Equal(expected, result);
            
        }

        [Fact]
        public void TestNotContainsDefaultDelimiter()
        {
            var numbers = "1,2,3,4";
            var expected = false;

            var result = StringCalculator.ContainsDefaultDelimiter(numbers);
            
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void TestGetDefaultDelimiter()
        {
            var expected = new char[]{';'};
            var numbers = "//;\n1;2";
            
            var result = StringCalculator.GetDefaultDelimiter(numbers);
            
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestGetDefaultDelimiterWithoutFirstLine()
        {
            var expected = new char[] {',', '\n'};
            var numbers = "1,2,3,4";

            var result = StringCalculator.GetDefaultDelimiter(numbers);
            
            Assert.Equal(expected, result);
        }


        [Fact]
        public void TestWithNegativeNumber()
        {
            var numbers = "1,-2,3";
            var exception = Assert.Throws<ArgumentException>(() => StringCalculator.Add(numbers));
            Assert.Equal("negatives not allowed: -2", exception.Message);
        }
        
        [Fact]
        public void TestWithNegativeNumbers()
        {
            var numbers = "1,-2,3,-4,-55";
            var exception = Assert.Throws<ArgumentException>(() => StringCalculator.Add(numbers));
            Assert.Equal("negatives not allowed: -2,-4,-55", exception.Message);
        }
    }
}