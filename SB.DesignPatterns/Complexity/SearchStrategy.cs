using System;
using System.Collections.Generic;
using System.Text;

namespace SB.DesignPatterns.Complexity
{
    public class ForeachSearchStrategy : ISearchStrategy
    {
        public bool Search(List<int> list, int number)
        {
            foreach (int num in list)
            {
                if (num == number)
                    return true;
            }
            return false;
        }
    }
    public class FindSearchStrategy : ISearchStrategy
    {
        public bool Search(List<int> list, int number)
        {
            return list.Find(r => r == number) != 0;
        }
    }
    public class InListOrderedSearchStrategy : ISearchStrategy
    {
        public bool Search(List<int> list, int number)
        {
            return InListOrdered(list.ToArray(), number);
        }
        public bool InListOrdered(int[] list, int number)
        {
            if (list.Length > 1)
            {
                double tempIndex = list.Length / 2;
                int middleIndex = (int)Math.Floor(tempIndex);
                if (list[middleIndex] > number)
                {
                    ArraySegment<int> segment = new ArraySegment<int>(list, middleIndex, list.Length - middleIndex);
                    return InListOrdered(segment.ToArray(), number);
                }
                else if (list[middleIndex] < number)
                {
                    ArraySegment<int> segment = new ArraySegment<int>(list, 0, middleIndex);
                    return InListOrdered(segment.ToArray(), number);
                }
                else
                    return true;
            }
            else
                return false;
        }
    }
    public class BinaryRangeLimitStrategy : ISearchStrategy
    {
        public bool Search(List<int> list, int number)
        {
            return InListOrdered(list.ToArray(), number, 0, list.Count - 1);
        }
        public static bool InListOrdered(int[] list, int number, int start, int end)
        {
            int length = end - start;
            if (length > 1)
            {
                double tempIndex = length / 2;
                int middleIndex = start + (int)Math.Floor(tempIndex);
                if (list[middleIndex] > number)
                {
                    return InListOrdered(list, number, start, middleIndex);
                }
                else if (list[middleIndex] < number)
                {
                    return InListOrdered(list, number, middleIndex, end);
                }
                else
                    return true;
            }
            else
                return false;
        }
    }
    public class InListBinaryOwnSearchStrategy : ISearchStrategy
    {
        public bool Search(List<int> list, int number)
        {
            return InListBinaryOwn(list.ToArray(), number);
        }
        public static bool InListBinaryOwn(int[] list, int number)
        {
            int leftIndex = 0;
            int rightIndex = list.Length - 1;
            while (leftIndex < rightIndex)
            {
                double tempIndex = (leftIndex + rightIndex) / 2;
                int middleIndex = (int)Math.Floor(tempIndex);
                if (list[middleIndex] > number)
                    rightIndex = middleIndex;
                else if (list[middleIndex] < number)
                    leftIndex = middleIndex + 1;
                else
                    return true;
            }
            return false;
        }
    }
}
