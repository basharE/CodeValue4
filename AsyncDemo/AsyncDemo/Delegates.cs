using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncDemo
{
    public  delegate IEnumerable<int> PrimesCalculator(int firstArgument, int secondArgument);
    internal static class Delegates
    {
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
