using System;
using System.Collections.Generic;
using System.Text;

namespace SB.DesignPatterns.Strategy
{
    public class Fib
    {
        public virtual int Compute(int n)
        {
            if (n == 0 || n == 1)
                return n;
            else
                return Compute(n - 1) + Compute(n - 2);
        }
    }
}
