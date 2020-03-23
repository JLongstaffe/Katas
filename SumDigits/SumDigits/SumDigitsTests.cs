
using NUnit.Framework;

namespace SumDigits
{
    internal class SumDigitsTests
    {
        [TestCase(0,  ExpectedResult = 0)]
        [TestCase(9,  ExpectedResult = 45)]
        [TestCase(10, ExpectedResult = 46)]
        [TestCase(15, ExpectedResult = 66)]
        public int Sums_all_digits(int n)
        {
            return SumDigits.Sum(n);
        }
    }
}
