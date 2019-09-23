
export function Get(n: number): number
{
    if (n < 1) throw new RangeError("Input must be positive")

    var generator = Series(n);

    for (let i = 0; i < n - 1; i++)
    {
        generator.next()
    }

    return generator.next().value;
}

export function AsArray(n: number): Array<number>
{
    if (n < 1) throw new RangeError("Input must be positive");

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
