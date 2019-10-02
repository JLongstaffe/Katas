
using System.Collections.Generic;

namespace Permutations
{
    public static class Permutations
    {
        public static ISet<string> Of(string input)
        {
            return FindPermutations(input, string.Empty, new HashSet<string>());
        }

        private static ISet<string> FindPermutations
            (string input,
             string prefix,
             ISet<string> results)
        {
            if (input.Length == 0) results.Add(prefix);

            for (var i = 0; i < input.Length; i++)
            {
                FindPermutations(input.Substring(0, i) + input.Substring(i + 1),
                                 prefix + input[i],
                                 results);
            }

            return results;
        }
    }
}
