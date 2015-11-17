namespace MathMatrix
{
    using System;
    using MathMatrix.Libs;

    public class EntryPoint
    {
        public static void Main()
        {
            Matrix first = new Matrix(3, 3);
            first.Elements[0, 0] = 2;
            first.Elements[0, 1] = 25;
            first.Elements[0, 2] = -5;

            first.Elements[1, 0] = 12;
            first.Elements[1, 1] = 8;
            first.Elements[1, 2] = -45;

            first.Elements[2, 0] = 14;
            first.Elements[2, 1] = -45;
            first.Elements[2, 2] = 0;

            Matrix second = new Matrix(3, 3);
            second.Elements[0, 0] = 25;
            second.Elements[0, 1] = 50;
            second.Elements[0, 2] = -2;

            second.Elements[1, 0] = 120;
            second.Elements[1, 1] = -10;
            second.Elements[1, 2] = -100;

            second.Elements[2, 0] = 32;
            second.Elements[2, 1] = -101;
            second.Elements[2, 2] = 98;

            try
            {
                Console.WriteLine(first + second);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();

            try
            {
                Console.WriteLine(first - second);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();

            try
            {
                Console.WriteLine(first * second);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
        }
    }
}
