// Write a program that enters a number from 10 to 19 and prints on the
// console the name of the number. E.g. 11 – “eleven”. Use switch.

using System;

class PrintName
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        switch (number)
        {
            case 10:
                Console.WriteLine("Ten");
                break;
            case 11:
                Console.WriteLine("Eleven");
                break;
            case 12:
                Console.WriteLine("Twelve");
                break;
            case 13:
                Console.WriteLine("Thirteen");
                break;
            case 14:
                Console.WriteLine("Fourteen");
                break;
            case 15:
                Console.WriteLine("Fifteen");
                break;
            case 16:
                Console.WriteLine("Sixteen");
                break;
            case 17:
                Console.WriteLine("Seventeen");
                break;
            case 18:
                Console.WriteLine("Eighteen");
                break;
            case 19:
                Console.WriteLine("Nineteen");
                break;
            default: 
                Console.WriteLine("Wrong number");
                break;
        }
    }
}

