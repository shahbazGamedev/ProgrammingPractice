using System;

namespace HashTable
{
    public class Test
    {
        public static void Main()
        {
            HashTable<int, string> testTable = new HashTable<int, string>();

            testTable.Add(1, "test");

            string test = testTable.GetValue(1);
            Console.WriteLine(test);

            testTable.Delete(1);
            Console.WriteLine(testTable.GetValue(1));
        }
    }
}

