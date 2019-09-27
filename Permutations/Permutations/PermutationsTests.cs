
using System.Diagnostics;
using System.Linq;

using NUnit.Framework;

namespace Permutations
{
    internal sealed class PermutationsTests
    {
        [TestCase("",     new [] { "" })]
        [TestCase("ab",   new [] { "ab", "ba" })]
        [TestCase("abc",  new [] { "abc", "acb", "bac", "bca", "cab", "cba" })]
        [TestCase("abcd", new []
        {
            "abcd", "abdc", "acbd", "acdb", "adbc", "adcb",
            "bacd", "badc", "bcad", "bcda", "bdac", "bdca",
            "cabd", "cadb", "cbad", "cbda", "cdab", "cdba",
            "dabc", "dacb", "dbac", "dbca", "dcab", "dcba"
        })]
        public void Returns_correct_permutations(string input, string[] expected)
        {
            Assert.That(Permutations.Of(input), Is.EquivalentTo(expected));
        }

        [Test]
        public void Benchmark()
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            var result = Permutations.Of("01234567");

            stopwatch.Stop();

            Assert.That(result.Contains("01234567"));

            Assert.That(result.Count, Is.EqualTo(40_320)); // 8!

            Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThan(10_000));
        }
    }
}
