using FluentAssertions;
using Xunit;

namespace CSharp.Problems_001_050
{
    public class P004_LargestPalindromeProduct
    {
        bool IsPalindromic(int value)
        {
            // Negative numbers are never palindromic
            if (value < 0) return false;

            // Single digit numbers are alway palindromic
            if (value < 10) return true;

            // Convert to a string and do character comparisons
            var s = $"{value}";
            for (var i = 0; i < s.Length / 2; i++)
                if (s[i] != s[s.Length - (i + 1)]) return false;

            return true;
        }

        int LargestPalindromicPrime(int range)
        {
            var highest = 0;
            var highestJ = 0; // Once the inner loop drops below this value, we'll never be avle to get a higher value than highest

            for (var i = range; i > highestJ; i--)
                for (var j = range; j > highestJ; j--)
                {
                    var v = i * j;
                    // v is only ever going to decrease from here, so don't bother continuing to check if it's lower than the highest value
                    if (v < highest) break;
                    if (IsPalindromic(v))
                    {
                        highest = v;
                        highestJ = j;
                        break; // v will only decrese after this, so no point calulating any more for this value of j
                    }
                }

            return highest;
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(33)]
        [InlineData(99)]
        [InlineData(121)]
        [InlineData(1221)]
        [InlineData(9009)]
        [InlineData(65456)]
        public void PalindromicNumbers(int number) => IsPalindromic(number).Should().Be(true);

        [Theory]
        [InlineData(-1)]
        [InlineData(31)]
        [InlineData(59)]
        [InlineData(123)]
        [InlineData(1241)]
        [InlineData(9209)]
        [InlineData(63456)]
        public void NotPalindromicNumbers(int number) => IsPalindromic(number).Should().Be(false);

        [Fact]
        public void Example() => LargestPalindromicPrime(99).Should().Be(9009);

        [Fact]
        public void Solution() => LargestPalindromicPrime(999).Should().Be(906609);
    }
}
