
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeNumbers
{
    /// <summary>
    /// Finds the nth prime number using the Sieve of Eratosthenes
    /// </summary>
    ///
    public class PrimeNumbers
    {
        /// <param name="maxPrime">
        /// The maximum possible prime number than can be found
        /// </param>
        ///
        public PrimeNumbers(int maxPrime)
        {
            if (maxPrime <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxPrime));
            }

            m_Sieve = new bool[maxPrime];
        }

        /// <returns>
        /// The nth prime number, or 0 if the prime could not be found within
        /// the maximum configured range.
        /// </returns>
        ///
        public int GetPrime(int n) => Primes().Skip(n - 1)
                                              .FirstOrDefault();

        private IEnumerable<int> Primes()
        {
            for (var candidate = 2; candidate < m_Sieve.Length; candidate++)
            {
                if (m_Sieve[candidate]) continue;

                yield return candidate;

                UpdateSieve(candidate);
            }
        }

        private void UpdateSieve(int prime)
        {
            for (var multiple = 1; prime * multiple < m_Sieve.Length; multiple++)
            {
                m_Sieve[prime * multiple] = true;
            }
        }

        private readonly bool[] m_Sieve;
    }
}
