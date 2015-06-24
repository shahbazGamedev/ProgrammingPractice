namespace LambdaDivisibleNums
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Test
    {
        public static void Main()
        {
            int[] numbers = new int[10];

            numbers[0] = 1; 
            numbers[1] = 14; 
            numbers[2] = -2; 
            numbers[3] = 21; 
            numbers[4] = 49; 
            numbers[5] = 55; 
            numbers[6] = -20; 
            numbers[7] = 3; 
            numbers[8] = 7; 
            numbers[9] = 100;

            var divisibleNumbers = numbers.Where(n => n % 3 == 0 || n % 7 == 0).ToArray();

            for (int i = 0; i < divisibleNumbers.Length; i++)
            {
                Console.WriteLine(divisibleNumbers[i]);
            }
        }
    }
}
