
using System;
using System.Collections.Generic;
using System.Linq;

namespace GreedyWords
{
    public class GreedyWords
    {
        public GreedyWords(ISet<string> dictionary)
        {
            m_Dictionary = dictionary
                        ?? throw new ArgumentNullException(nameof(dictionary));
        }

        public IReadOnlyCollection<string> GetWords(string input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var words = new Stack<string>();

            return GetWords(input, words)
                 ? words.AsEnumerable().Reverse().ToArray()
                 : null;
        }

        private bool GetWords(string input, Stack<string> words)
        {
            if (m_Dictionary.Contains(input))
            {
                words.Push(input);

                return true;
            }

            for (var i = input.Length - 1; i > 0; i--)
            {
                if (!m_Dictionary.Contains(input.Substring(0, i))) continue;

                words.Push(input.Substring(0, i));

                if (GetWords(input.Substring(i), words)) return true;
            }

            if (words.Count > 0) words.Pop();

            return false;
        }

        private readonly ISet<string> m_Dictionary;
    }
}
