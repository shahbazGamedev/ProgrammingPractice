// Sort 3 integer numbers using if statements.

using System;

class Sort
{
    static void Main()
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());
        int thirdNumber = int.Parse(Console.ReadLine());

        // for convenience:
        bool BiggerOfFirstAndThird = (firstNumber > thirdNumber);
        bool BiggerOfFirstAndSecond = (firstNumber > secondNumber);
        bool BiggerOfSecondAndThird = (secondNumber > thirdNumber);

        Console.WriteLine();

        if (BiggerOfFirstAndSecond && BiggerOfFirstAndThird)
        {
            if (BiggerOfSecondAndThird)
            {
                Console.WriteLine(firstNumber);
                Console.WriteLine(secondNumber);
                Console.WriteLine(thirdNumber);
            }
            else
            {
                Console.WriteLine(firstNumber);
                Console.WriteLine(thirdNumber);
                Console.WriteLine(secondNumber);
            }
        }
        else if (BiggerOfFirstAndSecond && BiggerOfSecondAndThird)
        {
            if (BiggerOfFirstAndThird)
            {
                Console.WriteLine(secondNumber);
                Console.WriteLine(firstNumber);
                Console.WriteLine(thirdNumber);
            }
            else
            {
                Console.WriteLine(secondNumber);
                Console.WriteLine(thirdNumber);
                Console.WriteLine(firstNumber);
            }
        }
        else
        {
            if (BiggerOfFirstAndSecond)
            {
                Console.WriteLine(thirdNumber);
                Console.WriteLine(firstNumber);
                Console.WriteLine(secondNumber);
            }
            else
            {
                Console.WriteLine(thirdNumber);
                Console.WriteLine(secondNumber);
                Console.WriteLine(firstNumber);
            }
        }
    }
}

