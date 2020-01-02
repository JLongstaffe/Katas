
export function Get(n: number): number
{
    if (n < 0) throw new RangeError("Input must not be negative")

    let [current, next] = [0, 1];

    for (let i = 0; i < n; i++)
    {
        [current, next] = [next, current + next];
    }

    return current;
}
