using System;
using LinkedList;

namespace SelectionSort
{
    public class Test
    {
        public static void Main()
        {
            LinkedList<int> testList = new LinkedList<int>();

            testList.AddLast(1);
            testList.AddLast(13);
            testList.AddLast(6);
            testList.AddLast(9);
            testList.AddLast(50);

            testList.Sort();

            foreach (var item in testList)
            {
                Console.WriteLine(item);
            }
        }
    }
}

