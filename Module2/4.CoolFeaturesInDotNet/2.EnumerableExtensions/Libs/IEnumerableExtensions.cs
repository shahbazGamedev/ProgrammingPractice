namespace EnumerableExtensions.Libs
{
    using System.Collections.Generic;

    public static class IEnumerableExtensions
    {
        public static IEnumerable<int> Sum(this IEnumerable<int> numbers)
        {
            int sum = 0;

            foreach (int n in numbers)
            {
                yield return sum + n;
            }
        }
    }
}
