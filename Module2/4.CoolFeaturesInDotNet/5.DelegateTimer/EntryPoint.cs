namespace DelegateTimer
{
    using System;
    using System.Threading;

    public class EntryPoint
    {
        private delegate string Del(string str);

        public static void Main()
        {
            Del handler = DelegateMethod;
            
            while (true)
            {
                Console.WriteLine(handler("Hello!"));
                Thread.Sleep(1000);
            }
        }

        private static string DelegateMethod(string text)
        {
            return text;
        }
    }
}
