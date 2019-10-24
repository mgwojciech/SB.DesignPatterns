using System;
using System.Collections.Generic;
using System.Text;

namespace SB.DesignPatterns.Model
{
    public class ProductPlan
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double MarketingCost { get; set; }
        public double InfrastructureCost { get; set; }
        public double UnitProductionCost { get; set; }
        public double UnitPrice { get; set; }
    }
}
