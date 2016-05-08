using FluentAssertions;
using Xunit;

namespace CSharp.Problems_001_050
{
    public class P015_LatticePaths
    {
        long NumPaths(int gridSize)
        {
            long[,] grid = new long[gridSize, gridSize];


            // Prime the first column
            for (var i = 0; i < gridSize; i++)
                grid[i, 0] = i + 2;

            for (var i = 1; i < gridSize; i++)
            {
                // The i,i position is always double the cell next to it
                grid[i, i] = grid[i - 1, i] * 2;
                for (var j = i + 1; j < gridSize; j++)
                    grid[i, j] = grid[i - 1, j] + grid[i, j - 1];
            }

            // THe last corner cell with contain the value we want
            return grid[gridSize-1, gridSize-1];
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 6)]
        [InlineData(3, 20)]
        [InlineData(4, 70)]
        [InlineData(5, 252)]
        public void Example(int gridSize, long numPaths) => NumPaths(gridSize).Should().Be(numPaths);

        [Fact]
        public void Solution() => NumPaths(20).Should().Be(137846528820);
    }
}
