using System;
using LinkedList;

namespace MergeSort
{
    public class Test
    {
        public static void Main()
        {
            LinkedList<int> testList = new LinkedList<int>();

            testList.AddLast(2);
            testList.AddLast(7);
            testList.AddLast(123);
            testList.AddLast(8);
            testList.AddLast(5);
            testList.AddLast(12);

            testList = testList.Sort(0, testList.Count - 1);

            foreach (var item in testList)
            {
                Console.WriteLine(item);
            }
        }
    }
}

