
import { performance } from "perf_hooks";

import { PrimeNumbers } from "./prime-numbers";

test("Cannot construct with negative maximum prime", () =>
{
    expect(() => new PrimeNumbers(-1)).toThrow(RangeError);
});

test("Rejects numbers less than one", () =>
{
    expect(() => new PrimeNumbers(1).GetPrime(-1)).toThrow(RangeError);
})

test("Returns nth Fibonacci number", () =>
{
    [[1,   2],
     [2,   3],
     [3,   5],
     [4,   7],
     [5,   11],
     [10,  29],
     [20,  71],
     [100, 541]]
    .forEach(([input, expected]) =>
    {
        let primeNumbers = new PrimeNumbers(1000);

        expect(primeNumbers.GetPrime(input)).toBe(expected);
    });
});

test("Throws error if requested prime exceeds maximum prime", () =>
{
    let primeNumbers = new PrimeNumbers(4);

    expect(() => primeNumbers.GetPrime(3)).toThrow(RangeError);
});

test("Can reuse same instance", () =>
{
    let primeNumbers = new PrimeNumbers(100);

    primeNumbers.GetPrime(3);

    expect(primeNumbers.GetPrime(4)).toBe(7);
});

test("Benchmark", () =>
{
    let primeNumbers = new PrimeNumbers(5_000_000);

    const start = performance.now();

    var result = primeNumbers.GetPrime(100_000);

    const stop = performance.now();

    expect(result).toBe(1_299_709);

    expect(stop - start).toBeLessThan(500);
});