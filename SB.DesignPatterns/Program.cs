using ClosedXML.Excel;
using SB.DesignPatterns.Builder;
using SB.DesignPatterns.DAL;
using SB.DesignPatterns.Mocks;
using SB.DesignPatterns.Model;
using SB.DesignPatterns.Reports;
using SB.DesignPatterns.Strategy;
using System;
using System.Collections.Generic;
using System.Data;

namespace SB.DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            #region OOP3
            ////LoginReport report = new LoginReport();
            ////report.GenerateReport("Report.xlsx");
            //ReportBuilder builder = new ComposedBuilder(new List<ReportBuilder>()
            //{
            //    new ReportBuilder(),
            //    new AppLoginReportBuilder(),
            //});
            //ReportDirector director = new ReportDirector();

            //var report = director.BuildReport(builder);
            //var greatSmartThing = new ProductPlan()
            //{
            //    Id = 1,
            //    InfrastructureCost = 200000,
            //    MarketingCost = 500000,
            //    ProductName = "SmartThing",
            //    UnitPrice = 200,
            //    UnitProductionCost = 10
            //};
            //double riskFactor = AnalyzeRisk(greatSmartThing);

            //Ackermann ack = new Ackermann();
            //for(int i = 0; i <5;i++)
            //{
            //    for(int j = 0; j< 5; j++)
            //    {
            //        Console.WriteLine(ack.Compute(i, j));
            //    }
            //}

            //MemoizeFib fib = new MemoizeFib();
            //var result = fib.Compute(10);

            //result = fib.Compute(11);
            #endregion

        }

        private static double AnalyzeRisk(ProductPlan greatSmartThing)
        {
            double riskFactor = 1;
            double initialCost = greatSmartThing.InfrastructureCost + greatSmartThing.MarketingCost;
            if (initialCost > 100000)
                riskFactor *= 0.75;
            riskFactor *= ((greatSmartThing.UnitPrice - greatSmartThing.UnitProductionCost) / greatSmartThing.UnitPrice);

            return riskFactor;
        }
    }
}
