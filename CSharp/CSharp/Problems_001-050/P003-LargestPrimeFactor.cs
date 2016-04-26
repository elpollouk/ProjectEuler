using CSharp.Utils;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CSharp.Problems_001_050
{
    public class P003_LargestPrimeFactor
    {
        long LargestPrimeFactor(long value)
        {
            while (!Maths.IsPrime(value))
            {
                // Special case for 2
                if (value % 2 == 0) value /= 2;
                else for (int i = 3; i < (value / 2); i += 2) // We know that no other even number is going to be a prime factor, so why even bother checking them?
                {
                    if (Maths.IsPrime(i) && value % i == 0)
                    {
                        value /= i;
                        break;
                    }
                }
            }

            return value;
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(4, false)]
        [InlineData(5, true)]
        [InlineData(6, false)]
        [InlineData(7, true)]
        [InlineData(8, false)]
        [InlineData(9, false)]
        [InlineData(10, false)]
        [InlineData(11, true)]
        [InlineData(12, false)]
        [InlineData(13, true)]
        [InlineData(14, false)]
        [InlineData(15, false)]
        [InlineData(23, true)]
        public void Primes(long value, bool expected) => Maths.IsPrime(value).Should().Be(expected);

        [Fact]
        public void Example() => LargestPrimeFactor(13195).Should().Be(29);

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(4, 2)]
        [InlineData(5, 5)]
        [InlineData(6, 3)]
        [InlineData(7, 7)]
        [InlineData(8, 2)]
        [InlineData(9, 3)]
        [InlineData(10, 5)]
        [InlineData(23, 23)]
        public void Check(long value, long largestPrime) => LargestPrimeFactor(value).Should().Be(largestPrime);

        [Fact]
        public void Solution() => LargestPrimeFactor(600851475143).Should().Be(6857);
    }
}
