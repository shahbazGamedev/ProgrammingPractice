using System;

namespace Queue
{
    public class Test
    {
        public static void Main()
        {
            Queue<int> testQueue = new Queue<int>();

            testQueue.Enqueue(1);
            testQueue.Enqueue(2);
            testQueue.Enqueue(3);

            Console.WriteLine(testQueue.Peek());

            testQueue.Dequeue();
            Console.WriteLine(testQueue.Peek());

            testQueue.Dequeue();
            Console.WriteLine(testQueue.Peek());
        }
    }
}

