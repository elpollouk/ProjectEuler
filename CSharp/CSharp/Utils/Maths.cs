using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Utils
{
    public class Maths
    {
        public static bool IsPrime(long value)
        {
            if (value == 1 || value == 2) return true;

            for (var i = 2; i * i <= value; i++)
            {
                if (value % i == 0) return false;
            }

            return true;
        }
    }
}
