
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fibonacci
{
    internal sealed class Fibonacci
    {
        public static long Get(int n)
        {
            if (n < 0) throw new ArgumentOutOfRangeException(nameof(n));

            return Series().Skip(n).First();
        }

        private static IEnumerable<long> Series()
        {
            var (current, next) = ((long) 0, (long) 1);

            while (true)
            {
                yield return current;

                (current, next) = (next, current + next);
            }
        }
    }
}
