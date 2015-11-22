using System;

namespace Stack
{
	public class Test
	{
		public static void Main()
		{
			Stack<int> testStack = new Stack<int>();
			testStack.Push(1);
			testStack.Push(2);
			testStack.Push(3);

			Console.WriteLine(testStack.Peek());
			testStack.Pop();

			Console.WriteLine(testStack.Peek());
			testStack.Pop();

			Console.WriteLine(testStack.Peek());
			testStack.Pop();

			Console.WriteLine(testStack.Peek());
		}
	}
}

