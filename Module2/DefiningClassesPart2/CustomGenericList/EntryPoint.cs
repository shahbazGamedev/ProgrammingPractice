namespace CustomGenericList
{
    using System;
    using System.Collections.Generic;
    using CustomGenericList.Libraries;
    
    public class EntryPoint
    {
        public static void Main()
        {
            CustomList<int> myList = new CustomList<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(5);

            myList[2] = 15;
            Console.WriteLine(myList + "\n");

            myList.RemoveAt(2);
            Console.WriteLine(myList + "\n");

            myList.InsertAt(0, 10);
            Console.WriteLine(myList + "\n");

            Console.WriteLine("Does the list contain the number 2? " + myList.Find(2) + "\n");

            myList.Clear();
            Console.WriteLine(myList.Count);
        }
    }
}
