using CSharp.Utils;
using FluentAssertions;
using Xunit;

namespace CSharp.Problems_001_050
{
    public class P018_MaximumPathSum
    {
        private int[] Row(params int[] row) => row;

        private static long MaxPathSum(params int[][] rows)
        {
            for (var row = rows.Length - 2; row >= 0; row--)
                for (var i = 0; i < rows[row].Length; i++)
                    rows[row][i] += Maths.Max(rows[row + 1][i], rows[row + 1][i + 1]);

            return rows[0][0];
        }

        [Fact]
        public void Example()
        {
            MaxPathSum(
                Row(3),
                Row(7, 4),
                Row(2, 4, 6),
                Row(8, 5, 9, 3)
            ).Should().Be(23);
        }

        [Fact]
        public void Solution()
        {
            MaxPathSum(
                Row(75),
                Row(95, 64),
                Row(17, 47, 82),
                Row(18, 35, 87, 10),
                Row(20,  4, 82, 47, 65),
                Row(19,  1, 23, 75,  3, 34),
                Row(88,  2, 77, 73,  7, 63, 67),
                Row(99, 65,  4, 28,  6, 16, 70, 92),
                Row(41, 41, 26, 56, 83, 40, 80, 70, 33),
                Row(41, 48, 72, 33, 47, 32, 37, 16, 94, 29),
                Row(53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14),
                Row(70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57),
                Row(91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48),
                Row(63, 66,  4, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31),
                Row( 4, 62, 98, 27, 23,  9, 70, 98, 73, 93, 38, 53, 60,  4, 23)
            ).Should().Be(1074);
        }
    }
}
