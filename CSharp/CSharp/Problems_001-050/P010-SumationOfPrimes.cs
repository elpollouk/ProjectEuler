using CSharp.Utils;
using FluentAssertions;
using Xunit;

namespace CSharp.Problems_001_050
{
    public class P010_SumationOfPrimes
    {
        long PrimeSums(int range)
        {
            long sum = 2;
            for (var i = 3; i < range; i += 2)
            {
                if (Maths.IsPrime(i))
                    sum += i;
            }
            return sum;
        }

        [Fact]
        public void Example() => PrimeSums(10).Should().Be(17);

        [Fact]
        public void Solution() => PrimeSums(2000000).Should().Be(142913828922);
    }
}
