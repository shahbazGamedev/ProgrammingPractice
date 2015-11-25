using System;
using LinkedList;

namespace InsertionSort
{
    public class Test
    {
        public static void Main()
        {
            LinkedList<int> testList = new LinkedList<int>();

            testList.AddLast(1);
            testList.AddLast(12);
            testList.AddLast(61);
            testList.AddLast(3);
            testList.AddLast(8);

            testList.Sort();

            foreach (var item in testList)
            {
                Console.WriteLine(item);
            }
        }
    }
}

