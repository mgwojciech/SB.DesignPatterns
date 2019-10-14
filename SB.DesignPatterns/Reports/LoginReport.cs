using ClosedXML.Excel;
using Newtonsoft.Json;
using SB.DesignPatterns.DAL;
using SB.DesignPatterns.Mocks;
using SB.DesignPatterns.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SB.DesignPatterns.Reports
{
    public class LoginReport
    {
        public void GenerateReport(string reportPath)
        {
            IDataProvider<User> provider = MockStaticProvider.GetUserDataProvider();

            DataTable table = SetColumns();
            IEnumerable<User> usersInReport = GetData(provider);
            ProcessData(table, usersInReport);
            return table;

            XLWorkbook reportWorkBook = new XLWorkbook();
            reportWorkBook.AddWorksheet(table);
            reportWorkBook.SaveAs(reportPath);

            DataSet resultSet = new DataSet();
            resultSet.Tables.Add(table);
            resultSet.WriteXml("report.xml");

            System.IO.File.WriteAllText("report.json", JsonConvert.SerializeObject(resultSet, Formatting.Indented));
        }

        private void ProcessData(DataTable table, IEnumerable<User> usersInReport)
        {
            foreach (User user in usersInReport)
            {
                DataRow row = table.NewRow();

                row[0] = user.FirstName;
                row[1] = user.LastName;
                row[2] = user.LoginName;
                row[3] = GetUserLastLogin(user);

                table.Rows.Add(row);
            }
        }

        private static IEnumerable<User> GetData(IDataProvider<User> provider)
        {
            return provider.GetData(user => user.Id > 0);
        }

        private static DataTable SetColumns()
        {
            DataTable table = new DataTable("UsersLogin");
            table.Columns.Add("FirstName");
            table.Columns.Add("LastName");
            table.Columns.Add("Login");
            table.Columns.Add("LastLoginDate");
            return table;
        }

        protected virtual object GetUserLastLogin(User user)
        {
            return new DateTime();
        }
    }
}
