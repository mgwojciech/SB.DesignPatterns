using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SB.DesignPatterns.Builder
{
    public class ReportDirector
    {
        public DataTable BuildReport(ReportBuilder builder)
        {
            builder.SetColumns();
            builder.GetData();
            builder.ProcessData();

            return builder.ReportTable;
        }
    }
}
