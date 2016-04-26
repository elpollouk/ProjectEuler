using CSharp.Utils;
using FluentAssertions;
using Xunit;

namespace CSharp.Problems_001_050
{
    public class P006_SumSquareDifference
    {
        int Calc(int range)
        {
            var sumRange = Maths.SumNaturalNumbers(range);
            var sumSquare = Maths.SumNaturalSquare(range);

            return (sumRange * sumRange) - sumSquare;
        }

        [Fact]
        public void Example() => Calc(10).Should().Be(2640);

        [Fact]
        public void Solution() => Calc(100).Should().Be(25164150);
    }
}
