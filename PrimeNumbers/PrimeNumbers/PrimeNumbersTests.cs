
using System;
using System.Diagnostics;

using NUnit.Framework;

namespace PrimeNumbers
{
    internal sealed class PrimeNumbersTests
    {
        [TestCase(0)]
        [TestCase(-1)]
        public void Cannot_contruct_with_invalid_arguments(int maxPrime)
        {
            Assert.That(() => new PrimeNumbers(maxPrime),
                        Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Returns_zero_if_prime_not_found_within_configured_range()
        {
            Assert.That(() => new PrimeNumbers(2).GetPrime(2), Is.EqualTo(0));
        }

        [TestCase(  1,   ExpectedResult =   2)]
        [TestCase(  2,   ExpectedResult =   3)]
        [TestCase(  3,   ExpectedResult =   5)]
        [TestCase(  4,   ExpectedResult =   7)]
        [TestCase(  5,   ExpectedResult =  11)]
        [TestCase( 10,   ExpectedResult =  29)]
        [TestCase( 20,   ExpectedResult =  71)]
        [TestCase(100,   ExpectedResult = 541)]
        public int Returns_nth_prime(int n)
            => new PrimeNumbers(1000).GetPrime(n);

        [Test]
        public void Benchmark()
        {
            var primeNumbers = new PrimeNumbers(5_000_000);

            var stopwatch = new Stopwatch();

            stopwatch.Start();

            Assert.That(primeNumbers.GetPrime(100_000), Is.EqualTo(1_299_709));

            stopwatch.Stop();

            Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThan(100));
        }
    }
}
