
using System;
using System.Diagnostics;

using NUnit.Framework;

namespace Fibonacci
{
    internal sealed class FibonacciTests
    {
        [TestCase(-2)]
        [TestCase(-1)]
        public void Rejects_negative_numbers(int n)
        {
            Assert.That(() => Fibonacci.Get(n),
                        Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(5, 5)]
        [TestCase(20, 6765)]
        public void Returns_nth_fibonacci_number(int n, long expected)
        {
            Assert.That(Fibonacci.Get(n), Is.EqualTo(expected));
        }

        [Test]
        public void Benchmark()
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            var result = Fibonacci.Get(90);

            stopwatch.Stop();

            Assert.That(result, Is.EqualTo(2_880_067_194_370_816_120));

            Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThan(5));
        }
    }
}
