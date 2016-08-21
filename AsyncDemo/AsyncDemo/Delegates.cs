using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncDemo
{
    //Good name
    public  delegate IEnumerable<int> PrimesCalculator(int firstArgument, int secondArgument);
    // Why Static Class ??
    internal static class Delegates
    {
        // why static?
        public static  IEnumerable<int> CalcPrimes(int first, int second)
        {
            var returnResult = new List<int>();
            for (int i = first; i < second; i++)
            {
                if (IsPrime(i))
                {
                    returnResult.Add(i);
                }
            }
            return  returnResult;
        }
        // why static?
        private static bool IsPrime(int num)
        {
            var result = true;
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
