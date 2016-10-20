using FluentAssertions;
using Xunit;

namespace CSharp.Problems_001_050
{
    public class P017_NumberLetterCounts
    {
        private static int UnitsLetterCount(int number)
        {
            switch (number)
            {
                case 1: return "one".Length;
                case 2: return "two".Length;
                case 3: return "three".Length;
                case 4: return "four".Length;
                case 5: return "five".Length;
                case 6: return "six".Length;
                case 7: return "seven".Length;
                case 8: return "eight".Length;
                case 9: return "nine".Length;
                case 10: return "ten".Length;
                case 11: return "eleven".Length;
                case 12: return "twelve".Length;
                case 13: return "thirteen".Length;
                case 14: return "fourteen".Length;
                case 15: return "fifteen".Length;
                case 16: return "sixteen".Length;
                case 17: return "seventeen".Length;
                case 18: return "eighteen".Length;
                case 19: return "nineteen".Length;
            }

            return 0;
        }

        private static int TensLetterCount(int number)
        {
            switch (number)
            {
                case 2: return "twenty".Length;
                case 3: return "thirty".Length;
                case 4: return "forty".Length;
                case 5: return "fifty".Length;
                case 6: return "sixty".Length;
                case 7: return "seventy".Length;
                case 8: return "eighty".Length;
                case 9: return "ninety".Length;
            }

            return 0;
        }

        private static int LetterCount(int number)
        {
            if (number == 1000) return "onethousand".Length;

            var hundreds = number / 100;
            number %= 100;
            var count = UnitsLetterCount(hundreds);
            if (count != 0)
            {
                count += "hundred".Length;
                count += (number != 0) ? "and".Length : 0;
            }

            var tens = number / 10;
            if (tens == 1)
                tens = 0;
            else
                number %= 10;

            return count + TensLetterCount(tens) + UnitsLetterCount(number);
        }

        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 3)]
        [InlineData(3, 5)]
        [InlineData(4, 4)]
        [InlineData(5, 4)]
        [InlineData(6, 3)]
        [InlineData(7, 5)]
        [InlineData(8, 5)]
        [InlineData(9, 4)]
        [InlineData(10, 3)]
        [InlineData(11, 6)]
        [InlineData(12, 6)]
        [InlineData(13, 8)]
        [InlineData(14, 8)]
        [InlineData(15, 7)]
        [InlineData(16, 7)]
        [InlineData(17, 9)]
        [InlineData(18, 8)]
        [InlineData(19, 8)]
        [InlineData(20, 6)]
        [InlineData(21, 9)]
        [InlineData(30, 6)]
        [InlineData(32, 9)]
        [InlineData(40, 5)]
        [InlineData(43, 10)]
        [InlineData(50, 5)]
        [InlineData(54, 9)]
        [InlineData(60, 5)]
        [InlineData(65, 9)]
        [InlineData(70, 7)]
        [InlineData(76, 10)]
        [InlineData(80, 6)]
        [InlineData(87, 11)]
        [InlineData(90, 6)]
        [InlineData(98, 11)]
        [InlineData(100, 10)]
        [InlineData(101, 16)]
        [InlineData(115, 20)]
        [InlineData(200, 10)]
        [InlineData(300, 12)]
        [InlineData(342, 23)]
        [InlineData(400, 11)]
        [InlineData(500, 11)]
        [InlineData(600, 10)]
        [InlineData(700, 12)]
        [InlineData(800, 12)]
        [InlineData(900, 11)]
        [InlineData(1000, 11)]
        [InlineData(0, 0)]
        public void SingleNumberCounts(int number, int expectedLetterCount) => LetterCount(number).Should().Be(expectedLetterCount);

        [Fact]
        public void Solution()
        {
            var total = 0;
            for (var i = 1; i <= 1000; i++)
                total += LetterCount(i);

            total.Should().Be(21124);
        }
    }
}
