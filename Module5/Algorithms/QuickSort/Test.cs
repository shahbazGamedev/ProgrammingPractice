using System;
using LinkedList;

namespace QuickSort
{
    public class Test
    {
        public static void Main()
        {
            LinkedList<int> testList = new LinkedList<int>();

            testList.AddLast(1);
            testList.AddLast(6);
            testList.AddLast(34);
            testList.AddLast(88);
            testList.AddLast(2);
            testList.AddLast(5);

            testList.Sort(0, testList.Count - 1);

            foreach (var item in testList)
            {
                Console.WriteLine(item);
            }
        }
    }
}

