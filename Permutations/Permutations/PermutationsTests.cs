
using System.Diagnostics;

using NUnit.Framework;

namespace Permutations
{
    internal sealed class PermutationsTests
    {
        [TestCase("",     new [] { "" })]
        [TestCase("a",    new [] { "a" })]
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
        public void Duplicates_are_ignored()
        {
            Assert.That(Permutations.Of("aab"),
                        Is.EquivalentTo(new [] { "aab", "aba", "baa" }));
        }

        [Test]
        public void Benchmark()
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            var result = Permutations.Of("0123456789");

            stopwatch.Stop();

            Assert.That(result.Contains("9876543210"));

            Assert.That(result.Count, Is.EqualTo(3_628_800)); // 10!

            Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThan(5000));
        }
    }
}
