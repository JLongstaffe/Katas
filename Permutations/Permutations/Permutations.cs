
using System.Collections.Generic;
using System.Linq;

namespace Permutations
{
    public static class Permutations
    {
        public static IReadOnlyCollection<string> Of(string input)
        {
            return Of(input, string.Empty, new List<string>());
        }

        private static IReadOnlyCollection<string> Of
            (string input,
             string prefix,
             IList<string> results)
        {
            if (input.Length == 0) results.Add(prefix);

            for (var i = 0; i < input.Length; i++)
            {
                Of(input.Substring(0, i) + input.Substring(i + 1),
                   prefix + input[i],
                   results);
            }

            return results.ToArray();
        }
    }
}
