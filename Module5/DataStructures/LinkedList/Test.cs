using System;

namespace LinkedList
{
	public class Test
	{
		public static void Main ()
		{
			LinkedList<int> testList = new LinkedList<int> ();
			testList.AddFirst (1);
			testList.AddFirst (2);
			testList.AddFirst (3);
			testList.AddLast (4);
			testList.AddBefore (4, 8);

			Console.WriteLine (testList.Contains (0));
			Console.WriteLine (testList.Count);

			testList.Clear ();

			Console.WriteLine (testList.Count);

			testList.AddLast (11);
			testList.AddLast (14);
			testList.AddLast (16);
			testList.AddAfter (16, 15);
			testList.AddBefore (11, 30);

			foreach (int element in testList) {
				Console.WriteLine (element);
			}
		}
	}
}

