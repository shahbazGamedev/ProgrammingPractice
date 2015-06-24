namespace CustomFraction
{
    using System;
    using CustomFraction.Libraries;

    public class EntryPoint
    {
        public static void Main()
        {
            Fraction first = new Fraction(2, 4);
            Fraction second = new Fraction(5, 12);

            Console.WriteLine("Decimal: " + first.DecimalValue);
            Console.WriteLine("Decimal: " + second.DecimalValue);

            Console.WriteLine("{0} + {1} = {2} => {3}", first, second, first + second, Fraction.Simplify(first + second));

            first.Numerator = 5;
            first.Denominator = 7;
            second.Numerator = 13;
            second.Denominator = 2;

            Console.WriteLine("{0} - {1} = {2} => {3}", first, second, first - second, Fraction.Simplify(first - second));

            first.Numerator = 5;
            first.Denominator = 9;
            second.Numerator = 10;
            second.Denominator = 7;

            Console.WriteLine("{0} * {1} = {2} => {3}", first, second, first * second, Fraction.Simplify(first * second));

            first.Numerator = 6;
            first.Denominator = 8;
            second.Numerator = 9;
            second.Denominator = 12;

            Console.WriteLine("{0} : {1} = {2} => {3}", first, second, first / second, Fraction.Simplify(first / second));
        }
    }
}
