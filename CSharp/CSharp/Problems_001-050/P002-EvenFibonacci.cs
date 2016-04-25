using FluentAssertions;
using Xunit;

// Even Fibonacci numbers
// https://projecteuler.net/problem=2
namespace CSharp.Problems_001_050
{
    public class P002_EvenFibonacci
    {
        int Total(int valueLimit)
        {
            var a = 1;
            var b = 1;
            var c = 2;
            var sum = 0;

            while (c < valueLimit)
            {
                sum += c;

                // Taking advantage of the fact every third number is even as:
                // Odd + Odd = Even
                // Odd + Even = Odd
                // Even + Odd = Odd
                a = b + c;
                b = a + c;
                c = a + b;
            }

            return sum;
        }

        [Fact]
        public void Example() => Total(89).Should().Be(44);

        [Fact]
        public void Solution() => Total(4000000).Should().Be(4613732);
    }
}
