// Modify your last program and try to make it work for any number type,
// not just integer (e.g. decimal, float, byte, etc.). Use generic methods.

using System;

class GenericMethods
{
    public static void Main()
    {
        Console.WriteLine("Minimal: {0}", Min(1, 2, -3.6, 4, 5, 6));
        Console.WriteLine("Maximal: {0}", Max(1, 2, 3, 4, 5.3434, 6));
        Console.WriteLine("Average: {0}", Average(1, 2, 3.24234, 4, 5, 6));
        Console.WriteLine("Sum: {0}", Sum(1, 2, 3, 4, 5, 6.7756754));
        Console.WriteLine("Product: {0}\n", Product(1.3453, 2, 3, 4.4353453535, 5, 6));
    }

    private static T Min<T>(params T[] numbers)
    {
        dynamic min = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
            {
                min = numbers[i];
            }
        }
        return min;
    }

    private static T Max<T>(params T[] numbers)
    {
        dynamic max = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }
        return max;
    }

    private static T Average<T>(params T[] numbers)
    {
        dynamic sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum = sum + numbers[i];
        }
        return sum / numbers.Length;
    }

    private static T Sum<T>(params T[] numbers)
    {
        dynamic sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum = sum + numbers[i];
        }
        return sum;
    }

    private static T Product<T>(params T[] numbers)
    {
        dynamic product = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            product = product * numbers[i];
        }
        return product;
    }
}

