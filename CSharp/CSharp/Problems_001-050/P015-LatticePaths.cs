using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CSharp.Problems_001_050
{
    public class P015_LatticePaths
    {
        long NumPaths(int gridSize)
        {
            long[,] grid = new long[gridSize, gridSize];


            for (var i = 0; i < gridSize; i++)
            {
                grid[i, 0] = i + 2;
                grid[0, i] = i + 2;
            }

            for (var i = 1; i < gridSize; i++)
                for (var j = 1; j < gridSize; j++)
                    grid[i, j] = grid[i - 1, j] + grid[i, j - 1];

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
