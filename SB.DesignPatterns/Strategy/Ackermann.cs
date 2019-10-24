using System;
using System.Collections.Generic;
using System.Text;

namespace SB.DesignPatterns.Strategy
{
    public class Ackermann
    {
        public virtual int Compute(int m, int n)
        {
            if (m == 0)
                return n + 1;
            if (m > 0 && n == 0)
                return Compute(m - 1, 1);
            else
                return Compute(m - 1, Compute(m, n - 1));
        }
    }
}
