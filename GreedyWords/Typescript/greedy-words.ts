
export default function GetWords(input: string, dictionary: string[]): string
{
    return LazyWords(input, [], dictionary).next().value ?? null;
}

function* LazyWords(input: string, words: string[], dictionary: string[])
{
    if (dictionary.includes(input)) yield [...words, input];

    for (let i = input.length - 1; i > 0; i--)
    {
        if (!dictionary.includes(input.substr(0, i))) continue;

        words.push(input.substr(0, i));

        yield* LazyWords(input.substr(i), words, dictionary);
    }

    if (words.length > 0) words.pop();
}