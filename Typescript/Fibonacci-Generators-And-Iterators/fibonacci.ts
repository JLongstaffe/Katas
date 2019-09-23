
export function Get(n: number): number
{
    if (n < 0) throw new RangeError("Input cannot be negative")

    var generator = Series(n);

    let value = 0;

    let result =  generator.next();

    while (!result.done)
    {
        value = result.value;

        result = generator.next();
    }

    return value;
}

export function AsArray(n: number): Array<number>
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
