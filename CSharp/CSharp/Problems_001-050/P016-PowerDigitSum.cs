using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CSharp.Problems_001_050
{
    public class P016_PowerDigitSum
    {
        int PowerDigitSum(int powerOfTwo)
        {
            int highestDigit = 1;
            int[] bigNumber = new int[1000];
            bigNumber[0] = 1;

            while (powerOfTwo-- > 0)
            {
                int acc = 0;
                int i = 0;
                for (; i < highestDigit || acc != 0; i++)
                {
                    acc += bigNumber[i] * 2;
                    bigNumber[i] = acc % 10;
                    acc /= 10;
                }

                if (highestDigit < i)
                    highestDigit = i;
            }

            var sum = 0;
            foreach (var v in bigNumber)
                sum += v;

            return sum;
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 2)]
        [InlineData(4, 7)]
        [InlineData(8, 13)]
        [InlineData(12, 19)]
        [InlineData(16, 25)]
        [InlineData(20, 31)]
        [InlineData(24, 37)]
        [InlineData(28, 43)]
        [InlineData(96, 127)]
        [InlineData(100, 115)]
        public void Example(int power, int sum) => PowerDigitSum(power).Should().Be(sum);

        [Fact]
        public void Solution() => PowerDigitSum(1000).Should().Be(1366);
    }
}
