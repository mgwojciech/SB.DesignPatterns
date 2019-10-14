using SB.DesignPatterns.Model;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SB.DesignPatterns.Builder
{
    public class AppLoginReportBuilder : ReportBuilder
    {
        public AppLoginReportBuilder()
        {
        }
        public override void SetColumns()
        {
            ReportTable.Columns.Add("AppLastLogin");
        }
        public override void ProcessData()
        {
            foreach (User user in RawData)
            {
                DataRow row = FindRow(user);
                row["AppLastLogin"] = DateTime.Now;
            }
        }

        private DataRow FindRow(User user)
        {
            return ReportTable.Rows.Find(user.Id);
        }
    }
}
