// Declare a variable for each of the data types in this lecture and assign
// an appropriate value.

using System;
using System.Numerics;

class DeclareVars
{
    static void Main()
    {
        sbyte degreesOutside = -2;

        byte numberOfGroupsInTheAcademy = 2;

        short someShortInt = 32500 - 32700;

        ushort currentYear = 2015;

        int tenToThePowerOfTen = (int)Math.Pow(10, 10);

        uint tenToThePowerOfTwelve = (uint)Math.Pow(10, 12);

        long tenToThePowerOfFifteen = (int)Math.Pow(10, 15);

        ulong radiusOfTheObservableUniverse = 14000000000;

        BigInteger aReallyBigNumber = 9999999999999999999;


        float oneToSeven = 1.1234567f;

        double oneToFifteen = 1.123456789012345d;

        decimal oneToTwentyEight = 1.1234567890123456789012345678m;


        bool amIPoor = true;

        bool amIHappy = false;


        char letterC = 'C';


        string alphabet = "abcdefghijklmnopqrstuvwxyz";


        object iCanBeAnything = 12;
        iCanBeAnything = "I told you!";


        dynamic doNotEverUseMe = 15;
        doNotEverUseMe = "I said never!!";
    }
}

