using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace StringCalculator_Kata.Core
{
    public static class StringCalculator
    {
        public static string HelloWorld()
        {
            return "Hello World";
        }

        public static int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers)) return 0;

            var splitedNumbers = SplitNumbers(numbers);

            
            var parsed_numbers = ParseNumbers(splitedNumbers);
            CheckNegativeNumbers(parsed_numbers);
            var final_numbers = RemoveGreaterThanOneThousand(parsed_numbers);
            
            return final_numbers.Sum();
        }

        private static string[] SplitNumbers(string numbers)
        {
            return numbers
                .Split(GetDefaultDelimiter(numbers),
                    StringSplitOptions.RemoveEmptyEntries);
        }

        private static int[] ParseNumbers(string[] splitedNumbers)
        {
            var parsedNumbers = new int[splitedNumbers.Length];
            for (var x = 0; x < parsedNumbers.Length; x++)
            {
                int.TryParse(splitedNumbers[x], out var a);
                parsedNumbers[x] = a;
            }

            return parsedNumbers;
        }

        public static bool ContainsDefaultDelimiter(string numbers)
        {
            return numbers[0] == '/' && numbers[1] == '/' && numbers[3] == '\n';
        }
        
        public static char[] GetDefaultDelimiter(string numbers)
        {
            return ContainsDefaultDelimiter(numbers) ? new char[] {numbers[2]} : new char[]{',', '\n'};
        }

        private static void CheckNegativeNumbers(IEnumerable<int> numbers)
        {
            var negative_numbers = numbers.Where(n => n < 0);

            if (!negative_numbers.Any()) return;
            
            var joined = string.Join(",", negative_numbers);
            throw new ArgumentException(string.Format($"negatives not allowed: {joined}"));
        }

        public static IEnumerable<int> RemoveGreaterThanOneThousand(IEnumerable<int> parsed_numbers) =>    
        parsed_numbers.Where(n => n < 1000);
        
    }
}