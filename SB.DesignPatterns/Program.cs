using ClosedXML.Excel;
using SB.DesignPatterns.Builder;
using SB.DesignPatterns.DAL;
using SB.DesignPatterns.Mocks;
using SB.DesignPatterns.Model;
using SB.DesignPatterns.Reports;
using System;
using System.Collections.Generic;
using System.Data;

namespace SB.DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //LoginReport report = new LoginReport();
            //report.GenerateReport("Report.xlsx");
            ReportBuilder builder = new ComposedBuilder(new List<ReportBuilder>()
            {
                new ReportBuilder(),
                new AppLoginReportBuilder(),
            });
            ReportDirector director = new ReportDirector();

            var report = director.BuildReport(builder);
        }
    }
}
