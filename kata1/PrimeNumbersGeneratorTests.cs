using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace kata1
{
    [TestFixture]
    public class PrimeNumbersGeneratorTests
    {
        [TestCase(0)]
        [TestCase(1)]
        public void Generate_ReturnsEmptyCollection_ForThresholdZero(int input)
        {
            var generator = new PrimeNumbersGenerator();

            var primeNumbers = generator.Generate(input);

            CollectionAssert.AreEquivalent(new int[0], primeNumbers);
        }


        
        [TestCase(2, new[] {2})]
        [TestCase(3, new[] {2, 3})]
        public void Generate_ReturnsElementsOfSequenceAsInputNumber(int input, int[] expected)
        {
            var generator = new PrimeNumbersGenerator();

            var primeNumbers = generator.Generate(input);

            CollectionAssert.AreEquivalent(expected, primeNumbers);
        }

        [TestCase(4, new[] { 2, 3 })]
        [TestCase(15, new[] { 2, 3, 5, 7, 11, 13 })]
        [TestCase(100, new[] {2,3,5,7,11,
            13,17,19,23,29,
            31,37,41,43,47,
            53,59,61,67,71,
            73,79,83,89,97 })]
        public void Generate_ReturnsOnlyPrimeNumbers(int input, int[] expected)
        {
            var generator = new PrimeNumbersGenerator();

            var primeNumbers = generator.Generate(input);

            CollectionAssert.AreEquivalent(expected, primeNumbers);
        }
    }

    public class PrimeNumbersGenerator
    {
        public IEnumerable<int> Generate(int analyzeNumbersThreshold)
        {
            if (analyzeNumbersThreshold > 0)
            {
                foreach (var number in Enumerable.Range(1, analyzeNumbersThreshold))
                {
                    if(number==1)
                        continue;
                    var nis = Enumerable.Range(1, number-1);
                    var isPrime = true;
                    foreach (var ni in nis)
                    {
                        if (ni != 1 && number % ni == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime)
                        yield return number;
                }
            }
        }
    }
}
