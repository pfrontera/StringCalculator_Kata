using System;
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
            
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var splitedNumbers = numbers.Split(new char[]{',', '\n'},StringSplitOptions.RemoveEmptyEntries);

            
            var parsed_numbers = new int[splitedNumbers.Length];
            for (var x = 0; x < parsed_numbers.Length; x++)
            {
                int.TryParse(splitedNumbers[x], out var a);
                parsed_numbers[x] = a;
            }

            return parsed_numbers.Sum();
        }

        public static char GetDefaultDelimiter(string numbers)
        {
            if (numbers[0] == '/' && numbers[1] == '/' && numbers[3] == '\n')
            {
                return numbers[2];
            }

            foreach (var n in numbers)
            {
                if (!Char.IsDigit(n))
                {
                    return n;
                }
            }

            return ',';
        }

        
            
    }
}