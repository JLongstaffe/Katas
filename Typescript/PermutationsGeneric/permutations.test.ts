
import { getPermutations } from "./permutations";

import { performance } from "perf_hooks";

test("Permutations of empty array is empty", () =>
{
    expect(getPermutations([])).toEqual([[]]);
})

test("Returns correct permutations", () =>
{
    const permutations = getPermutations([0, 1, 2]);

    const expectedResults = [ [0, 1, 2], [0, 2, 1], [1, 0, 2],
                              [1, 2, 0], [2, 0, 1], [2, 1, 0] ];

    expect(permutations).toEqual(expectedResults);

    const mixedPermutations = getPermutations(["a", 1, null]);

    const mixedExpectedResults = [ ["a", 1, null], ["a", null, 1],
                                   [1, "a", null], [1, null, "a"],
                                   [null, "a", 1], [null, 1, "a"] ];

    expect(mixedPermutations).toEqual(mixedExpectedResults);
});

test("Benchmark", () =>
{
    const start = performance.now();

    let results = getPermutations<number>([0, 1, 2, 3, 4, 5, 6, 7]);

    const stop = performance.now();

    expect(results).toContainEqual([7, 6, 5, 4, 3, 2, 1, 0]);

    expect(results.length).toBe(40_320);

    expect(stop - start).toBeLessThan(500);
});