
export function Get(n: number): number
{
    if (n < 0) throw new RangeError("Input cannot be negative");

    let result = 0;

    for (let value of Series(n))
    {
        result = value;
    }

    return result;
}

export function ToArray(n: number): Array<number>
{
    if (n < 0) throw new RangeError("Input cannot be negative");

    return Array.from(Series(n));
}

function* Series(max: number): Generator<number>
{
    let [current, next] = [1, 1];

    for (let i = 0; i < max; i++)
    {
        yield current;

        [current, next] = [next, current + next];
    }
}
