using SB.DesignPatterns.DAL;
using SB.DesignPatterns.Mocks;
using SB.DesignPatterns.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SB.DesignPatterns.Builder
{
    public class ReportBuilder
    {
        public DataTable ReportTable { get; protected set; }
        public IEnumerable<User> RawData { get; protected set; }
        public ReportBuilder()
        {
            ReportTable = new DataTable("Report");
        }
        public virtual void SetColumns()
        {
            ReportTable.Columns.Add("FirstName");
            ReportTable.Columns.Add("LastName");
            ReportTable.Columns.Add("Login");
            ReportTable.Columns.Add("LastLoginDate");
        }
        public virtual void GetData()
        {
            IDataProvider<User> provider = MockStaticProvider.GetUserDataProvider();
            RawData = provider.GetData(user => user.Id > 0);
        }
        public virtual void ProcessData()
        {
            foreach(User user in RawData)
            {
                DataRow row = ReportTable.NewRow();

                row[0] = user.FirstName;
                row[1] = user.LastName;
                row[2] = user.LoginName;
                row[3] = GetUserLastLogin(user);

                ReportTable.Rows.Add(row);
            }
        }

        private DateTime GetUserLastLogin(User user)
        {
            return new DateTime();
        }
    }
}
