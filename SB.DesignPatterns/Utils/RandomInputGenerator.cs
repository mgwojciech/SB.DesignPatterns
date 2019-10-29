using System;
using System.Collections.Generic;
using System.Text;

namespace SB.DesignPatterns.Utils
{
    public class RandomInputGenerator
    {
        public static int GenerateRandomInt()
        {
            var generator = new Random();

            return generator.Next(int.MinValue, int.MaxValue);
        }
    }
}
