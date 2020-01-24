
export function* States(initialState: boolean[][]): Generator<boolean[][]>
{
    yield initialState;

    let state = initialState;

    while (true) yield (state = NextState(state));
}

function NextState(state: boolean[][]): boolean[][]
{
    return state.map
        ((row, y) => row.map
            ((column, x) => NextAlive(state, x, y)));
}

function NextAlive(state: boolean[][], x: number, y: number): boolean
{
    const isAlive = state[y][x];

    const neighbours = CountNeighbours(state, x, y);

    return ( isAlive && [2, 3].includes(neighbours))
        || (!isAlive && neighbours === 3);
}

function CountNeighbours(state: boolean[][], column: number, row: number): number
{
    const InBounds = (x: number, y: number) => y >= 0 && y < state.length
                                            && x >= 0 && x < state[y].length;

    const IsAlive = (x: number, y: number) => InBounds(x, y) && state[y][x];

    return Cartesian([column - 1, column, column + 1],
                     [row - 1, row, row + 1])
          .filter(([x, y]) => x !== column || y !== row)
          .filter(([x, y]) => IsAlive(x, y))
          .length;
}

function Cartesian<T>(a1: T[], a2: T[]): T[][]
{
    return a1.flatMap(x => a2.map(y => [x, y]));
}
