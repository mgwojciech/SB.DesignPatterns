using System;
using System.Collections.Generic;
using System.Text;

namespace SB.DesignPatterns.Utils
{
    public class MonitoringHelper
    {
        public static TimeSpan RunInMonitoredScope(Action operation, int repeatCount = 1)
        {
            DateTime startDate = DateTime.Now;
            for(int i = 0; i <= repeatCount; i++)
            {
                operation();
            }
            return (DateTime.Now - startDate)/repeatCount;
        }
    }
}
