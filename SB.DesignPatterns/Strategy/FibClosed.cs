using System;
using System.Collections.Generic;
using System.Text;

namespace SB.DesignPatterns.Strategy
{
    public class FibClosed : Fib
    {
        public FibClosed()
        {
        }
        public override int Compute(int n)
        {
            double leftPart = Math.Pow(1 + Math.Sqrt(5), n);
            double rightPart = Math.Pow(1 - Math.Sqrt(5), n);
            double divider = Math.Pow(2, n);

            return Convert.ToInt32((leftPart + rightPart) / divider);
        }
    }
}
