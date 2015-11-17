namespace SBExtension
{
    using System;
    using System.Text;
    using SBExtension.Libs;
    
    public class Test
    {
        public static void Main()
        {
            StringBuilder text = new StringBuilder("some random words and letters");

            Console.WriteLine(text.Substring(5, 5));
        }
    }
}
