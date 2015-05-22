// Write a program to check if in a given expression the brackets are put
// correctly. Correct:((x-y)/(10-z)). Incorrect: )(x*y)-1).

using System;

class Brackets
{
    static void Main()
    {
        Console.Write("Input your string: ");
        string someExpression = Console.ReadLine();

        int leftBracketCounter = 0;
        int rightBracketCounter = 0;

        for (int i = 0; i < someExpression.Length; i++)
        {
            if (someExpression[i] == '(')
            {
                leftBracketCounter++;
            }
            else if (someExpression[i] == ')')
            {
                rightBracketCounter++;
            }
        }

        Console.WriteLine("The brackets are correctly closed: {0}", leftBracketCounter == rightBracketCounter);
    }
}

