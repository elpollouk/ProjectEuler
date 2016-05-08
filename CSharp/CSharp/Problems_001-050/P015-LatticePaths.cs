using FluentAssertions;
using Xunit;

namespace CSharp.Problems_001_050
{
    public class P015_LatticePaths
    {
        long NumPaths(int gridSize)
        {
            // We use this as a calculation buffer with the final answer ending up in the last cell
            long[] grid = new long[gridSize];

            // Prime the first column
            for (var i = 0; i < gridSize; i++)
                grid[i] = i + 2;

            for (var i = 1; i < gridSize; i++)
            {
                // The i,i position is always double the previous calculation
                grid[i] = grid[i] * 2;
                for (var j = i + 1; j < gridSize; j++)
                    grid[j] = grid[j] + grid[j - 1];
            }

            // The last cell contains the value we want
            return grid[gridSize-1];
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 6)]
        [InlineData(3, 20)]
        [InlineData(4, 70)]
        [InlineData(5, 252)]
        [InlineData(6, 924)]
        public void Example(int gridSize, long numPaths) => NumPaths(gridSize).Should().Be(numPaths);

        [Fact]
        public void Solution() => NumPaths(20).Should().Be(137846528820);
    }
}
