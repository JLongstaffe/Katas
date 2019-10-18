
using System.Linq;
using System.Threading;

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

        [Test, Timeout(1000)]
        public void Benchmark()
        {
            var result = Permutations.Of("012345678");

            Assert.That(result.ToArray().Contains("876543210"));

            Assert.That(result.Count, Is.EqualTo(362_880)); // 9!
        }

        [Test, Timeout(500)]
        public void Benchmark_duplicates()
        {
            var result = Permutations.Of("aaaabbbbcccc");

            Assert.That(result.ToArray().Contains("ccccbbbbaaaa"));

            Assert.That(result.Count(), Is.EqualTo(34650)); // 12!/(4!)^3;
        }
    }
}
