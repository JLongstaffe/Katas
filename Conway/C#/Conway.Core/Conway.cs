
using System;
using System.Collections.Generic;
using System.Linq;

using static System.Linq.Enumerable;

using ReadOnly2DBool = System.Collections.Generic.IReadOnlyList
                        <System.Collections.Generic.IReadOnlyList<bool>>;

namespace Conway.Core
{
    public static class Conway
    {
        public static IEnumerable<ReadOnly2DBool> States
            (ReadOnly2DBool initialState)
        {
            if (initialState is null)
            {
                throw new ArgumentNullException(nameof(initialState));
            }

            ReadOnly2DBool state;

            yield return state = initialState;

            while (true) yield return state = NextState(state);
        }

        private static ReadOnly2DBool NextState(ReadOnly2DBool state)
        {
            return state.Select
                ((row, y) => row.Select
                    ((column, x) => NextAlive(state, x, y)))
                .To2DArray();
        }

        private static bool NextAlive(ReadOnly2DBool state, int x, int y)
        {
            var isAlive = state[y][x];

            var neighbours = CountNeighbours(state, x, y);

            return (isAlive && new [] { 2, 3 }.Contains(neighbours))
                || (!isAlive && neighbours == 3);
        }

        private static int CountNeighbours(ReadOnly2DBool state, int column, int row)
        {
            bool InBounds(int x, int  y) => (y >= 0 && y < state.Count)
                                         && (x >= 0 && x < state[y].Count);

            bool IsAlive(int x, int y) => InBounds(x, y) && state[y][x];

            return Range(column - 1, 3)
                  .Cartesian(Range(row - 1, 3))
                  .Where(p => p != (column, row))
                  .Count(p => IsAlive(p.x, p.y));
        }

        private static IEnumerable<(T x, T y)> Cartesian<T>
            (this IEnumerable<T> e1, IEnumerable<T> e2)
        {
            return e1.SelectMany(x => e2.Select(y => (x, y)));
        }

        private static T[][] To2DArray<T>(this IEnumerable<IEnumerable<T>> e)
        {
            return e.Select(a => a.ToArray()).ToArray();
        }
    }
}
