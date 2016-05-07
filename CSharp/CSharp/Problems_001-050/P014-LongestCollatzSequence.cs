using FluentAssertions;
using Xunit;

namespace CSharp.Problems_001_050
{
    public class P014_LongestCollatzSequence
    {
        int[] _cache;

        int SequenceLength(long start)
        {
            if (start == 1) return 0;
            if (start < _cache.Length && _cache[start] != 0)
                return _cache[start];

            long v;
            if ((start & 1) == 0)
                v = start / 2;
            else
                v = (start * 3) + 1;

            var count = SequenceLength(v) + 1;
            if (start < _cache.Length)
                _cache[start] = count;

            return count;
        }

        long LongestStart(long range)
        {
            _cache = new int[(range * 3) + 1];

            long longestStart = 1;
            var longestLength = 0;

            while (range != 1)
            {
                var l = SequenceLength(range);
                if (longestLength < l)
                {
                    longestLength = l;
                    longestStart = range;
                }
                range--;
            }

            return longestStart;
        }

        [Fact]
        public void Example()
        {
            _cache = new int[41];
            SequenceLength(13).Should().Be(9);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(5, 3)]
        [InlineData(6, 6)]
        [InlineData(8, 7)]
        [InlineData(10, 9)]
        public void Check(long start, long longest) => LongestStart(start).Should().Be(longest);

        [Fact]
        public void Solution() => LongestStart(999999).Should().Be(837799);
    }
}
