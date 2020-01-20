
function* States(initialState: boolean[][]): Generator<boolean[][]>
{
    yield initialState;

    let state: boolean[][];

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

    return (isAlive && [2, 3].includes(neighbours))
        || (!isAlive && neighbours == 3);
}

function CountNeighbours(state: boolean[][], x: number, y: number): number
{
    const InBounds = (x: number, y: number) => y > 0 && y < state.length
                                            && x > 0 && x < state[0].length;

    const IsAlive = (x: number, y: number) => InBounds(x, y) && state[y][x];

    return Cartesian([x - 1, x, x + 1],
                     [y - 1, y, y + 1])
          .filter(p => p != [x, y])
          .filter(([x, y]) => IsAlive(x, y))
          .length;
}

function Cartesian<T>(a1: T[], a2: T[]): T[][]
{
    return a1.flatMap(x => a2.map(y => [x, y]));
}
