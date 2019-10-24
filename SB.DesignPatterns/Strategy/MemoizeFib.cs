using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SB.DesignPatterns.Strategy
{
    public class MemoizeFib : Fib
    {
        protected Dictionary<int, int> Memory { get; set; } =
            new Dictionary<int, int>(50);
        protected Dictionary<int, int> AccessStatistics 
            = new Dictionary<int, int>();

        public override int Compute(int n)
        {
            if (AccessStatistics.ContainsKey(n))
                AccessStatistics[n]++;
            else
                AccessStatistics.Add(n, 1);
            if (Memory.ContainsKey(n))
                return Memory[n];
            else
            {
                int tempResult = base.Compute(n);
                if(Memory.EnsureCapacity(n) < n)
                {
                    int indexToRemove = AccessStatistics.OrderBy(v => v.Value).FirstOrDefault().Key;
                    Memory.Remove(indexToRemove);
                }
                Memory.Add(n, tempResult);
                return tempResult;
            }
        }
    }
}
