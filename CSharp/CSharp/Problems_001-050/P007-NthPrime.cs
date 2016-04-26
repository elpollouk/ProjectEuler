using CSharp.Utils;
using FluentAssertions;
using Xunit;

namespace CSharp.Problems_001_050
{
    public class P007_NthPrime
    {
        long NthPrime(int index)
        {
            // We start at 3, skipping 2
            index--;
            long prime = 2;
            long i = 3;

            while (index != 0)
            {
                while (!Maths.IsPrime(i))
                {
                    i += 2;
                }
                index--;
                prime = i;
                i += 2;
            }

            return prime;
        }

        [Fact]
        public void Example() => NthPrime(6).Should().Be(13);

        [Fact]
        public void Solution() => NthPrime(10001).Should().Be(104743);
    }
}
