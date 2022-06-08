using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace M8_LINQ_Debugging_and_Testing
{
    class NumberConverter
    {
        public static IEnumerable<int> ConvertNumbers(IEnumerable<int> input)
        {
            return input
                .Select(n => n * n)
                .Select(n => n / 2)
                .Select(n => n - 5)
                .Where(n => n > 0)
                .OrderByDescending(n => n);
        } 
    }

    [TestFixture]
    public class NumberConverterTests
    {
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { 10 }, new int[] { 45 })]
        [TestCase(new int[] { 6 }, new int[] { 13 })]
        [TestCase(new int[] { 10, 6 }, new int[] { 45, 13 })]
        [TestCase(new int[] { 6, 10 }, new int[] { 45, 13 })]
        //[TestCase(new int[] { 6, 8, 10, }, new int[] { 45, 13 })]
        public void TestConvertNumbers(int[] inputSequence, int[] expectedOutputSequence)
        {
            var actualOutputSequence = NumberConverter.ConvertNumbers(inputSequence);
            Assert.AreEqual(expectedOutputSequence, actualOutputSequence);
        }

    }
}
