
import { getPermutations } from "./permutations";

import { performance } from "perf_hooks";

test("Returns correct permutations", () =>
{
    const testCases : [string, string[]][] =
        [ ["",     [""]],
          ["a",    ["a"]],
          ["ab",   ["ab", "ba"]],
          ["abc",  ["abc", "acb", "bac", "bca", "cab", "cba"]],
          ["abcd", ["abcd", "abdc", "acbd", "acdb", "adbc",
                    "adcb", "bacd", "badc", "bcad", "bcda",
                    "bdac", "bdca", "cabd", "cadb", "cbad",
                    "cbda", "cdab", "cdba", "dabc", "dacb",
                    "dbac", "dbca", "dcab", "dcba"]] ];

    testCases.forEach(([input, expectedResults]) =>
    {
        expect(getPermutations(input)).toEqual(new Set(expectedResults));
    });
});

test("Duplicate permutations are ignored", () =>
{
    expect(getPermutations("aab")).toEqual(new Set(["aab", "baa", "aba"]));
})

test("Benchmark", () =>
{
    const start = performance.now();

    let results = getPermutations("0123456789");

    const stop = performance.now();

    expect(results).toContain("9876543210");

    expect(results.size).toBe(3_628_800);

    expect(stop - start).toBeLessThan(5000);
});