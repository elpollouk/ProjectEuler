using FluentAssertions;
using Xunit;

namespace CSharp.Problems_001_050
{
    public class P005_SmallestMultiple
    {
        bool IsDivisibleByRange(int value, int range)
        {
            var limit = range / 2;
            for (var i = range - 1; i > limit; i--)
                if (value % i != 0) return false;
            return true;
        }

        int SmallestMultiple(int range)
        {
            var value = range;
            while (true)
            {
                if (IsDivisibleByRange(value, range))
                    return value;
                value += range;
            }
        }

        [Fact]
        public void Check() => IsDivisibleByRange(2520, 10).Should().BeTrue();

        [Fact]
        public void Example() => SmallestMultiple(10).Should().Be(2520);

        [Fact]
        public void Solution() => SmallestMultiple(20).Should().Be(232792560);
    }
}
