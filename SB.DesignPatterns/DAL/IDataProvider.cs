using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SB.DesignPatterns.DAL
{
    public interface IDataProvider<T>
    {
        IEnumerable<T> GetData(Expression<Func<T,bool>> query);
    }
}
