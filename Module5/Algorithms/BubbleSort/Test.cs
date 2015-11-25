using System;
using LinkedList;

namespace BubbleSort
{
    public class Test
    {
        public static void Main()
        {
            LinkedList<int> testList = new LinkedList<int>();

            testList.AddLast(2);
            testList.AddLast(9);
            testList.AddLast(12);
            testList.AddLast(6);
            testList.AddLast(0);

            testList.Sort();

            foreach (var item in testList)
            {
                Console.WriteLine(item);
            }
        }
    }
}

