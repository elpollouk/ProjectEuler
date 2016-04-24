using FluentAssertions;
using Xunit;

// Multiples of 3 and 5
// https://projecteuler.net/problem=1
namespace CSharp.Problems_001_050
{
    public class P001_Multiples3and3
    {
        int Total(int range)
        {
            var total = 0;
            while (--range > 0)
            {
                if ((range % 3) == 0 || (range % 5) == 0)
                {
                    total += range;
                }
            }

            return total;
        }

        [Fact]
        public void Example() => Total(10).Should().Be(23);

        [Fact]
        public void Solution() => Total(1000).Should().Be(233168);
    }
}
