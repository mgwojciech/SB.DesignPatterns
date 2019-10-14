using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace SB.DesignPatterns.DAL
{
    public class MockDataProvider<T> : IDataProvider<T>
    {
        public List<T> Data { get; set; }
        public MockDataProvider(List<T> data)
        {
            Data = data;
        }
        public IEnumerable<T> GetData(Expression<Func<T, bool>> query)
        {
            return Data.AsQueryable().Where(query);
        }
    }
}
