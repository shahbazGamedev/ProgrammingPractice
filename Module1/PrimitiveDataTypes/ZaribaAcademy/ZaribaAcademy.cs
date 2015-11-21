// Declare two string variables and assign them with “Zariba” and
// “Academy”. Declare an object variable and assign it with the
// concatenation of the first two variables (mind adding an interval).
// Declare a third string variable and initialize it with the value of the object
// variable (you should perform type casting).

using System;

class ZaribaAcademy
{
    static void Main()
    {
        string firstString = "Zariba", secondString = "Academy";

        object zaribaAcademy = firstString + ' ' + secondString;

        string thirdString = (string)zaribaAcademy;
        Console.WriteLine(thirdString);

    }
}

