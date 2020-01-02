
using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace GreedyWords
{
    public sealed class GreedyWordsTests
    {
        [Test]
        public void Cannot_construct_with_null_dictionary()
        {
            Assert.That(() => new GreedyWords(null),
                        Throws.TypeOf<ArgumentNullException>());
        }

        [TestCase("")]
        [TestCase("a")]
        [TestCase("abc")]
        public void Returns_null_if_no_solution(string input)
        {
            var dictionary = new HashSet<string> { "ab", "d", "bc" };

            var greedyWords = new GreedyWords(dictionary);

            Assert.That(greedyWords.GetWords(input), Is.Null);
        }

        [TestCase("helloworld", "hello", "world")]
        [TestCase("thequickbrownfoxjumpsoverthelazydog",
                  "the", "quick", "brown", "fox", "jumps",
                  "overt", "he", "lazy", "dog")]
        [TestCase("brownerd", "brow", "nerd")]
        public void Returns_correct_words_matched_greedily
            (string input, params string[] expected)
        {
            var dictionary = new HashSet<string>
                { "he", "hell", "hello", "low", "or", "world",
                  "the", "quick", "bro", "brow", "brown", "own", "owner",
                  "fox", "ox", "jump", "jumps", "over", "overt", "la",
                  "lazy", "do", "dog", "nerd" };

            var greedyWords = new GreedyWords(dictionary);

            Assert.That(greedyWords.GetWords(input), Is.EqualTo(expected));
        }
    }
}
