
export function getPermutations<T>(input: T[]): T[][]
{
    return findPermutations(input, [], []);
}

function findPermutations<T>(input: T[], prefix: T[], results: T[][])
{
    if (input.length == 0) results.push(prefix);

    for (let i = 0; i < input.length; i++)
    {
        let remainder = input.filter((_, index) => index != i);

        findPermutations(remainder,
                         [...prefix, input[i]],
                         results);
    }

    return results;
}