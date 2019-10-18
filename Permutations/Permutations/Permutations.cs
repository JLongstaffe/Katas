
using System.Collections.Generic;

namespace Permutations
{
    public static class Permutations
    {
        public static IReadOnlyCollection<string> Of(string input)
        {
            var results = new List<string>();

            FindPermutations(input,
                             string.Empty,
                             results,
                             new HashSet<(string, string)>());

            return results;
        }

        private static void FindPermutations
            (string input,
             string prefix,
             IList<string> results,
             ISet<(string, string)> memo)
        {
            if (memo.Contains((prefix, input))) return;

            memo.Add((prefix, input));

            if (input.Length == 0) results.Add(prefix);

            for (var i = 0; i < input.Length; i++)
            {
                FindPermutations(input.Substring(0, i) + input.Substring(i + 1),
                                 prefix + input[i],
                                 results,
                                 memo);
            }
        }
    }
}
