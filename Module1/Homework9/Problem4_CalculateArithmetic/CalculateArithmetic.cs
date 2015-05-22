// Write methods to calculate minimum, maximum, average, sum and
// product of given set of integer numbers. Use variable number of arguments.

using System;

class CalculateArithmetic
{
    static void Main()
    {
        Console.WriteLine("Minimal: {0}", MinimalElement(1, 12, 6, 2, 12, 6, 3, 12));
        Console.WriteLine("Maximal: {0}", MaximalElement(1, 12, 6, 2, 12, 6, 3, 12));
        Console.WriteLine("Average: {0}", Average(1, 12, 6, 2, 12, 6, 3, 12));
        Console.WriteLine("Sum: {0}", Sum(1, 12, 6, 2, 12, 6, 3, 12));
        Console.WriteLine("Product: {0}\n", Product(1, 12, 6, 2, 12, 6, 3, 12));
    }

    private static int MinimalElement(params int[] numbers)
    {
        int min = numbers[0];
        foreach (var element in numbers)
        {
            if (element < min)
            {
                min = element;    
            }
        }
        return min;
    }

    private static int MaximalElement(params int[] numbers)
    {
        int max = numbers[0];
        foreach (var element in numbers)
        {
            if (element > max)
            {
                max = element;
            }
        }
        return max;
    }

    private static int Sum(params int[] numbers)
    {
        int sum = 0;
        foreach (var element in numbers)
        {
            sum += element;
        }
        return sum;
    }

    private static int Average(params int[] numbers)
    {
        return Sum(numbers) / numbers.Length;
    }

    private static int Product(params int[] numbers)
    {
        int product = 1;
        foreach (var element in numbers)
        {
            product *= element;
        }
        return product;
    }
}

