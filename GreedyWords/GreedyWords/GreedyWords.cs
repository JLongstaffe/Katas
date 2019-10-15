
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

            return GetWords(input, new Stack<string>()).FirstOrDefault();
        }

        private IEnumerable<IReadOnlyCollection<string>> GetWords
            (string input,
             Stack<string> words)
        {
            if (m_Dictionary.Contains(input))
            {
                words.Push(input);

                yield return words.AsEnumerable().Reverse().ToArray();

                words.Pop();
            }

            for (var i = input.Length - 1; i > 0; i--)
            {
                if (m_Dictionary.Contains(input.Substring(0, i)))
                {
                    words.Push(input.Substring(0, i));

                    foreach (var result in GetWords(input.Substring(i), words))
                    {
                        yield return result;
                    }
                }
            }

            if (words.Count > 0) words.Pop();
        }

        private readonly ISet<string> m_Dictionary;
    }
}
