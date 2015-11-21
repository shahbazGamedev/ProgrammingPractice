// Read two floating point numbers from the console. Write a program
// to successfully compare these floating point number with precision of
// 0.00001. e.g. 3.0006 and 3.1 false, 3.000007 and 3.000008 true

using System;

class CompareFloats
{
    static void Main()
    {
        // read two floats from the console (a typecasting from string type is needed because of ReadLine()):
        float firstFloat = float.Parse(Console.ReadLine());
        float secondFloat = float.Parse(Console.ReadLine());

        // make two floats that contain only the decimal part (e.g. 12,34 -> 0,34): 
        float firstFloatAfterDecimalPoint = (float)(firstFloat - Math.Truncate(firstFloat));
        float secondFloatAfterDecimalPoint = (float)(secondFloat - Math.Truncate(secondFloat));

        // convert these floats into strings and "cut" them starting from the second position (e.g. 0,34 -> 34):
        string firstFloatAfterDecimalPointToString = firstFloatAfterDecimalPoint.ToString().Substring(2);
        string secondFloatAfterDecimalPointToString = secondFloatAfterDecimalPoint.ToString().Substring(2);

        // a simple check if the first float (now a string) has equal number of digits after the point than
        // the second float:
        if (firstFloatAfterDecimalPointToString.Length == secondFloatAfterDecimalPointToString.Length)
        {
            Console.WriteLine(true);
        }
        else
        {
            Console.WriteLine(false);
        }
    }
}
