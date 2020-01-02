
export function getPermutations(input: string): Set<string>
{
    return findPermutations(input, "", new Set<string>([]));
}

function findPermutations(input: string, prefix: string, results: Set<string>)
{
    if (input.length == 0) results.add(prefix);

    for (let i = 0; i < input.length; i++)
    {
        findPermutations(input.substr(0, i) + input.substr(i + 1),
                         prefix + input.charAt(i),
                         results);
    }

    return results;
}