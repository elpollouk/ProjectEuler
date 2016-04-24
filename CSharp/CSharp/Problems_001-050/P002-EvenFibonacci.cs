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
            var selection = false;
            var a = 1;
            var b = 1;
            var sum = 0;

            while (a < valueLimit && b < valueLimit)
            {
                var current = a + b;
                if (current % 2 == 0)
                    sum += current;

                if (selection = !selection)
                    a = current;
                else
                    b = current;
            }

            return sum;
        }

        [Fact]
        public void Example() => Total(89).Should().Be(44);

        [Fact]
        public void Solution() => Total(4000000).Should().Be(4613732);
    }
}
