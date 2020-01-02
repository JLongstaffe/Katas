
export class PrimeNumbers
{
    constructor(maxPrime: number)
    {
        if (maxPrime < 0) throw new RangeError("maxPrime cannot be negative");

        this.seive = new Array(maxPrime);
    }

    public GetPrime(n: number): number
    {
        if (n < 1) throw new RangeError("n must be greater than zero");

        var primeGenerator = this.Primes();

        for (let i = 0; i < n - 1; i++)
        {
            primeGenerator.next();
        }

        return primeGenerator.next().value;
    }

    private *Primes(): Generator<number>
    {
        for (let candidate = 2; candidate < this.seive.length; candidate++)
        {
            if (this.seive[candidate]) continue;

            yield candidate;

            this.UpdateSeive(candidate);
        }

        throw new RangeError
            ("No more primes can be found with the configured maximum");
    }

    private UpdateSeive(prime: number): void
    {
        for (let multiple = prime * 2; multiple < this.seive.length; multiple += prime)
        {
            this.seive[multiple] = true;
        }
    }

    private readonly seive: boolean[];
}
