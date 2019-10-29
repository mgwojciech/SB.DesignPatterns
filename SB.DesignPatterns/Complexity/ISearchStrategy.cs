using System.Collections.Generic;

namespace SB.DesignPatterns.Complexity
{
    public interface ISearchStrategy
    {
        bool Search(List<int> list, int number);
    }
}