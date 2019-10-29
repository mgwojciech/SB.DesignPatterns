using ClosedXML.Excel;
using SB.DesignPatterns.Builder;
using SB.DesignPatterns.Complexity;
using SB.DesignPatterns.DAL;
using SB.DesignPatterns.Mocks;
using SB.DesignPatterns.Model;
using SB.DesignPatterns.Reports;
using SB.DesignPatterns.Strategy;
using SB.DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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


            int[] listSizes = new int[] { 1000, 2000, 4000, 8000, 16000 };
            int sampleSize = 10000;
            foreach (int listSize in listSizes)
                RunSample(listSize, sampleSize);
        }

        private static void RunSample(int listSize, int sampleSize)
        {
            List<int> exampleList = new List<int>(listSize);
            for (int i = 0; i < listSize; i++)
            {
                exampleList.Add(RandomInputGenerator.GenerateRandomInt());
            }
            exampleList = exampleList.OrderBy(r => r).ToList();
            ISearchStrategy strategy = new ForeachSearchStrategy();
            TimeSpan span = MonitoringHelper.RunInMonitoredScope(delegate ()
            {
                exampleList.FindInList(RandomInputGenerator.GenerateRandomInt(), strategy);
            }, sampleSize);
            Console.WriteLine($"Foreach {listSize} {sampleSize} {span.TotalMilliseconds}");

            strategy = new FindSearchStrategy();
            span = MonitoringHelper.RunInMonitoredScope(delegate ()
            {
                exampleList.FindInList(RandomInputGenerator.GenerateRandomInt(), strategy);
            }, sampleSize);
            Console.WriteLine($"Find {listSize} {sampleSize} {span.TotalMilliseconds}");

            strategy = new InListOrderedSearchStrategy();
            span = MonitoringHelper.RunInMonitoredScope(delegate ()
            {
                exampleList.FindInList(RandomInputGenerator.GenerateRandomInt(), strategy);
            }, sampleSize);

            Console.WriteLine($"Ordered D&C Copy {listSize} {sampleSize} {span.TotalMilliseconds}");

            strategy = new BinaryRangeLimitStrategy();
            span = MonitoringHelper.RunInMonitoredScope(delegate ()
            {
                exampleList.FindInList(RandomInputGenerator.GenerateRandomInt(), strategy);
            }, sampleSize);

            Console.WriteLine($"Ordered D&C move index {listSize} {sampleSize} {span.TotalMilliseconds}");
            span = MonitoringHelper.RunInMonitoredScope(delegate ()
            {
                exampleList.FindInList(RandomInputGenerator.GenerateRandomInt());
            }, sampleSize);
            Console.WriteLine($"Binary {listSize} {sampleSize} {span.TotalMilliseconds}");

            strategy = new InListBinaryOwnSearchStrategy();
            span = MonitoringHelper.RunInMonitoredScope(delegate ()
            {
                exampleList.FindInList(RandomInputGenerator.GenerateRandomInt(), strategy);
            }, sampleSize);
            Console.WriteLine($"BinaryOwn {listSize} {sampleSize} {span.TotalMilliseconds}");

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
