using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    public class ApplicationService : IApplicationService
    {
        public void Run(string[] args)
        {

            if (args.Length != 5)
            {
                Console.WriteLine("Please use program with hereafter arguments: <int1> <int2> <limit> <str1> <str2>");
                Console.WriteLine("int1: The first int divisor for replacement");
                Console.WriteLine("int2: The second int divisor for replacement");
                Console.WriteLine("limit: The upper limit of numbers to consider");
                Console.WriteLine("str1: The string to replace multiples of int1");
                Console.WriteLine("str2: The string to replace multiples of int2");
                return;
            }

            try
            {
                // Parse arguments
                int int1 = int.Parse(args[0]);
                int int2 = int.Parse(args[1]);
                int limit = int.Parse(args[2]);
                string str1 = args[3];
                string str2 = args[4];

                // Generate and print the result
                var result = GenerateReplacementList(int1, int2, limit, str1, str2);

                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Enter a key to escape");
                Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Arguments int1, int2, and limit must be integers.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            } 
        }

        /// <summary>
        /// Generates a list of strings based on the rules: 
        /// all multiples of int1 are replaced by str1, all multiples of int2 are replaced by str2, all multiples of int1 and int2 are replaced by str1 and str2
        /// </summary>
        /// <param name="int1">The first divisor for replacement</param>
        /// <param name="int2">The second divisor for replacement</param>
        /// <param name="limit">The upper limit of numbers to consider</param>
        /// <param name="str1">The string to replace multiples of int1</param>
        /// <param name="str2">The string to replace multiples of int2</param>
        /// <returns>A list of strings with replacements</returns>
        public List<string> GenerateReplacementList(int int1, int int2, int limit, string str1, string str2)
        {
            var result = new List<string>();

            for (int i = 1; i <= limit; i++)
            {
                if (i % int1 == 0 && i % int2 == 0)
                {
                    result.Add(str1 + str2);  // Multiples of both int1 and int2
                }
                else if (i % int1 == 0)
                {
                    result.Add(str1);  // Multiples of int1 only
                }
                else if (i % int2 == 0)
                {
                    result.Add(str2);  // Multiples of int2 only
                }
                else
                {
                    result.Add(i.ToString());  // Non-multiples of both
                }
            }

            return result;
        }
    }
}
