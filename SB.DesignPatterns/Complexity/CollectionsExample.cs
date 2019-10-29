using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SB.DesignPatterns.Complexity
{
    public static class CollectionsExample
    {
        public static bool FindInList(this List<int> list, int number, ISearchStrategy searchStrategy = null)
        {
            if (searchStrategy == null)
                return list.BinarySearch(number) >= 1;
            return searchStrategy.Search(list, number);
        }
    }
}
