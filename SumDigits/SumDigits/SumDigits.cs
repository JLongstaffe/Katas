
using System.Collections.Generic;
using System.Linq;

namespace SumDigits
{
    internal static class SumDigits
    {
        public static int Sum(int n)
        {
            return Enumerable.Range(1, n)
                  .SelectMany(ToDigits)
                  .Sum();
        }

        private static IEnumerable<int> ToDigits(int n)
        {
            for (var i = n; i > 0; i /= 10)
            {
                yield return i % 10;
            }
        }
    }
}
