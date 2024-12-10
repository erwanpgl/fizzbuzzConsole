using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyPhilipsFizzBuzz
{
    public class ApplicationService : IApplicationService
    {        
        public void Run(string[] args)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            string path_to_logo = "Ressources\\ascii-art.txt"; //from web site https://www.asciiart.eu/image-to-ascii           

            if (args.Length != 5)
            {
                AnimateLogo(path_to_logo);

                Console.ForegroundColor = ConsoleColor.Magenta;
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

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Replacement string calculation started, please wait...");

                List<string> result_remplacement = new List<string>();

                Task main_calcul_Task = Task.Run(() =>
                {                    
                    result_remplacement = GenerateReplacementList(int1, int2, limit, str1, str2);
                    
                });

                while (!main_calcul_Task.IsCompleted)
                {
                    AnimateLogo(path_to_logo);
                }


                //Display by Batch with a pause to be readable
                int batchSize = 20;
                // List to hold tasks List<Task> tasks = new List<Task>(); // Process each batch in a loop
                for (int i = 0; i < result_remplacement.Count; i += batchSize)
                {
                    var currentLinesBatch = result_remplacement.Skip(i).Take(batchSize).ToList();
                    foreach (var line in currentLinesBatch)
                    {
                        Console.WriteLine(line);
                    }
                    Console.WriteLine("\nPress any key to continue or ctrl c to exit");
                    Console.ReadKey();
                }

                Console.WriteLine("\nThank you for your patience\nPress any key to exit...");

                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine("\n \u00A9 Software Corporation");

                Console.ReadKey();
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

        /// <summary>
        /// Load an ascii art logo 
        /// </summary>
        /// <param name="logo"></param>
        void AnimateLogo(string path)
        {
            var logo = "";

            try
            {
                logo = File.ReadAllText(path);
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return;
            } 

            
            string[] animationFrames = logo.Split('\n');

            for (int i = 0; i < animationFrames.Length; i++)
            {
                Console.WriteLine(animationFrames[i]);
                Thread.Sleep(5);  
            }

        }
    }
}
