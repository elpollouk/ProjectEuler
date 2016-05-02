namespace CSharp.Utils
{
    public class Maths
    {
        public static bool IsPrime(long value)
        {
            if (value == 1) return false;
            if (value < 4) return true;
            if (value % 2 == 0) return false;
            if (value < 9) return true;
            if (value % 3 == 0) return false;

            for (var i = 5; i * i <= value; i += 6)
            {
                if (value % i == 0) return false;
                if (value % (i + 2) == 0) return false;
            }

            return true;
        }

        public static int SumNaturalNumbers(int range)
        {
            range = range * (range + 1);
            range /= 2;
            return range;
        }

        public static long SumNaturalNumbers(long range)
        {
            range = range * (range + 1);
            range /= 2;
            return range;
        }

        public static int SumNaturalSquare(int range)
        {
            range = range * (range + 1) * (2 * range + 1);
            range /= 6;
            return range;
        }

        public static int Max(int value, params int[] values)
        {
            var highest = value;

            foreach (var v in values)
                if (highest < v)
                    highest = v;

            return highest;
        }
    }
}
