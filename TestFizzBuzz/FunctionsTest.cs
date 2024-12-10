using FizzBuzz;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace TestFizzBuzz
{
    public class Tests
    {

        // The TestCase attribute is used to provide different sets of test data
        [TestCase(2, 3, 6, "Dos", "Tres", new string[] { "1", "Dos", "Tres", "Dos", "5", "DosTres" })]
        [TestCase(4, 6, 15, "Four", "Six", new string[] { "1", "2", "3", "Four", "5", "Six", "7", "Four", "9", "10", "11", "FourSix", "13", "14", "15" })]
        [TestCase(3, 5, 16, "fizz", "buzz", new string[] {"1","2","fizz","4","buzz","fizz","7","8","fizz","buzz","11","fizz","13","14","fizzbuzz","16" })]
        public void TestGenerateReplacementList(int int1, int int2, int limit, string str1, string str2, string[] expected)
        {
            
            // Act
            var result = ApplicationService.GenerateReplacementList(int1, int2, limit, str1, str2);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}