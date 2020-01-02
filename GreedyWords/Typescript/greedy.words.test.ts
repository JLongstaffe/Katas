
import getWords from './greedy-words';

test("Returns null if no solution", () =>
{
    const testCases = ["", "a", "abc"];

    testCases.forEach(input =>
    {
        expect(getWords(input, ["ab", "d", "bc"])).toBe(null);
    });
});

test("Returns correct words matched greedily", () =>
{
    const testCases =
        [ ["helloworld", "hello", "world"],

          ["thequickbrownfoxjumpsoverthelazydog",
           "the", "quick", "brown", "fox", "jumps", "overt", "he", "lazy", "dog"],

          ["brownerd", "brow", "nerd"] ];

    const dictionary = ["he", "hell", "hello", "low", "or", "world", "the",
                        "quick", "bro", "brow", "brown", "own", "owner", "fox",
                        "ox", "jump", "jumps", "over", "overt", "la", "lazy",
                        "do", "dog", "nerd"];

    testCases.forEach(([input, ...expectedResult]) =>
    {
        expect(getWords(input, dictionary)).toEqual(expectedResult);
    });
});
