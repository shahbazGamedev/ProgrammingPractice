namespace EnumerableExtensions.Libs
{
    using System.Collections.Generic;

    public static class IEnumerableExtensions
    {
        public static int Sum(this IEnumerable<int> numbers)
        {
            int sum = 0;

            foreach (int n in numbers)
            {
                sum += n;
            }

            return sum;
        }

        public static int Product(this IEnumerable<int> numbers)
        {
            int product = 1;

            foreach (int n in numbers)
            {
                product *= n;
            }

            return product;
        }

        public static int Min(this IEnumerable<int> numbers)
        {
            int min = int.MaxValue;

            foreach (int n in numbers)
            {
                if (n < min)
                {
                    min = n;
                }
            }

            return min;
        }


        public static int Max(this IEnumerable<int> numbers)
        {
            int max = int.MinValue;

            foreach (int n in numbers)
            {
                if (n > max)
                {
                    max = n;
                }
            }

            return max;
        }

        public static int Average(this IEnumerable<int> numbers)
        {
            int numberCount = 0;

            foreach (int n in numbers)
            {
                numberCount++;
            }

            return Sum(numbers) / numberCount;
        }
    }
}
