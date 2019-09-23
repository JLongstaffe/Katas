
import { performance } from "perf_hooks";

import * as Fibonacci from "./fibonacci";

test("Rejects negative numbers", () =>
{
    [-1 -2]
   .forEach(input => expect(() => Fibonacci.Get(input))
                    .toThrow(RangeError));
});

test("Returns nth Fibonacci number", () =>
{
    [[0,  0],
     [1,  1],
     [2,  1],
     [3,  2],
     [5,  5],
     [20, 6765]]
    .forEach(([input, expected]) => expect(Fibonacci.Get(input)).toBe(expected));
});

test("Benchmark", () =>
{
    const start = performance.now();

    var result = Fibonacci.Get(90);

    const stop = performance.now();

    expect(result).toBe(2_880_067_194_370_816_120);

    expect(stop - start).toBeLessThan(5);
});
