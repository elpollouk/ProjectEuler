using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CSharp.Problems_001_050
{
    public class P009_SpecialPythagoreanTriplet
    {
        int TripletProduct(int requiredSum)
        {
            for (var i = 1; i < requiredSum; i++)
            {
                for (var j = 1; j < requiredSum; j++)
                {
                    if (i + j < requiredSum / 2) continue;
                    var target = requiredSum - (i + j);
                    if (target < 0) break;

                    if (i * i + j * j == target * target)
                        return i * j * target;
                }
            }

            return 0;
        }

        [Fact]
        public void Example() => TripletProduct(12).Should().Be(60);

        [Fact]
        public void Solution() => TripletProduct(1000).Should().Be(31875000);
    }
}
