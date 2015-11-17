// Assign an integer variable with the value of 107 in hexadecimal format.
// Hint: Use Windows Calculator.

using System;

class AssignHex
{
    static void Main()
    {
        int decNumber = 107;

        string hexNumber = decNumber.ToString("X"); // string formatter
        Console.WriteLine(hexNumber);
    }
}

