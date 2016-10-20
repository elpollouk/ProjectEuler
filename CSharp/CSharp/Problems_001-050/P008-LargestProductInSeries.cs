using FluentAssertions;
using Xunit;

namespace CSharp.Problems_001_050
{
    public class P008_LargestProductInSeries
    {
        const string data = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";
        const string testData = "0123456789876543210";

        private static int CharToNumber(char c)
        {
            return c - '0';
        }

        private static long TotalWindow(int[] window)
        {
            long total = 1;
            foreach (var i in window)
                total *= i;

            return total;
        }

        long LargestProduct(string data, int windowSize)
        {
            var window = new int[windowSize];
            for (var i = 0; i < windowSize; i++)
                window[i] = CharToNumber(data[i]);

            var oldestNumber = 0;
            var currentWindowTotal = TotalWindow(window);
            var largest = currentWindowTotal;

            for (var i = windowSize; i < data.Length; i++)
            {
                window[oldestNumber++ % windowSize] = CharToNumber(data[i]);

                currentWindowTotal = TotalWindow(window);

                if (largest < currentWindowTotal)
                    largest = currentWindowTotal;
            }

            return largest;
        }

        [Fact]
        public void Example() => LargestProduct(data, 4).Should().Be(5832);

        [Theory]
        [InlineData(1, 9)]
        [InlineData(2, 72)]
        [InlineData(3, 576)]
        [InlineData(4, 4032)]
        [InlineData(5, 28224)]
        [InlineData(6, 169344)]
        [InlineData(7, 1016064)]
        [InlineData(8, 5080320)]
        [InlineData(9, 25401600)]
        [InlineData(10, 101606400)]
        [InlineData(11, 406425600)]
        [InlineData(12, 1219276800)]
        [InlineData(13, 3657830400)]
        [InlineData(14, 7315660800)]
        public void Check(int windowSize, long total) => LargestProduct(testData, windowSize).Should().Be(total);


        [Fact]
        public void Solution() => LargestProduct(data, 13).Should().Be(23514624000);
    }
}
