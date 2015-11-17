namespace EnumerableExtensions
{
    using System;
    using System.Collections.Generic;
    using EnumerableExtensions.Libs;

    public class Test
    {
        public static void Main()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

            var sum = numbers.Sum();
            Console.WriteLine("Sum: " + sum);

            var product = numbers.Product();
            Console.WriteLine("Product: " + product);

            var min = numbers.Min();
            Console.WriteLine("Min: " + min);

            var max = numbers.Max();
            Console.WriteLine("Max: " + max);

            var average = numbers.Average();
            Console.WriteLine("Average: " + average);
        }
    }
}
