using CSharp.Utils;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CSharp.Problems_001_050
{
    public class P012_HighlyDivisibleTriangularNumber
    {
        int Calc(int minimumNumDivisors)
        {
            if (minimumNumDivisors == 1) return 1;
            if (minimumNumDivisors == 2) return 3;

            minimumNumDivisors -= 1; // We can assume 1 and the number itself, but we only subtract one as we also want to round up in the next step
            minimumNumDivisors /= 2; // We only need to discover the first half of the divisors as they all correspond with a value from the second half of the divisors
            int v = 3;
            while (true)
            {
                var count = 0;
                var sum = Maths.SumNaturalNumbers(v);
                for (var i = 2; i * i <= sum; i++) // The first half of the divisors can all be found under the sqrt of sum
                {
                    if (sum % i == 0)
                    {
                        count++;
                        if (count >= minimumNumDivisors) return sum;
                    }
                }
                v++;
            }
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 3)]
        [InlineData(3, 6)]
        [InlineData(4, 6)]
        [InlineData(5, 28)]
        [InlineData(6, 28)]
        [InlineData(7, 36)]
        [InlineData(8, 36)]
        public void Example(int minNumDivisors, int expectedNumber) => Calc(minNumDivisors).Should().Be(expectedNumber);

        [Fact]
        public void Solution() => Calc(501).Should().Be(76576500);
    }
}
