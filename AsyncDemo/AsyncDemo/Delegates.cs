using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace AsyncDemo
{

    public  delegate IEnumerable<int> TheDelegate(int firstArgument, int secondArgument);

    internal static class Delegates
    {


        public static IEnumerable<int> CalcPrimes(int first, int second)
        {
            return Enumerable.Range(first, second).Where(IsPrime);
        }

        private static bool IsPrime(int num)
        {
            bool result = true;
            Parallel.For(2, (int) Math.Sqrt(num) + 1, (i, loop) =>
            {
                if (num%i == 0)
                {
                    result = false;
                    loop.Stop();
                }
            });
            return result;
        }
    }
}
