// Draw on the console a 3 by 6 rectangle with the symbol ¿.

using System;
using System.Text;

class DrawRect
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
     
        string rectangleWidth = "\u00BF\u00BF\u00BF\u00BF\u00BF\u00BF";
        string rectangleHeight = "\u00BF    \u00BF";

        Console.WriteLine(rectangleWidth);
        Console.WriteLine(rectangleHeight);
        Console.WriteLine(rectangleWidth);
    }
}

