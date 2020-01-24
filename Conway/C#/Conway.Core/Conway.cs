
using System;
using System.Collections.Generic;
using System.Linq;

using static System.Linq.Enumerable;

namespace Conway.Core
{
    public static class Conway
    {
        public static IEnumerable<bool[][]> States(bool[][] initialState)
        {
            if (initialState is null)
            {
                throw new ArgumentNullException(nameof(initialState));
            }

            bool[][] state;

            yield return state = initialState;

            while (true) yield return state = NextState(state);
        }

        private static bool[][] NextState(bool[][] state)
        {
            return state.Select
                ((row, y) => row.Select
                    ((column, x) => NextAlive(state, x, y)))
                .To2DArray();
        }

        private static bool NextAlive(bool[][] state, int x, int y)
        {
            var isAlive = state[y][x];

            var neighbours = CountNeighbours(state, x, y);

            return (isAlive && new [] { 2, 3 }.Contains(neighbours))
                || (!isAlive && neighbours == 3);
        }

        private static int CountNeighbours(bool[][] state, int column, int row)
        {
            bool InBounds(int x, int  y) => (y >= 0 && y < state.Length)
                                         && (x >= 0 && x < state[y].Length);

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
