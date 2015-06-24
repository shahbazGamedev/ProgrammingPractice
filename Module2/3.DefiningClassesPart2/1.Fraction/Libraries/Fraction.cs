namespace CustomFraction.Libraries
{
    using System;

    public class Fraction
    {
        private int numerator;
        private int denominator;

        public Fraction()
        {
        }

        public Fraction(int numerator, int denominator)
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public int Numerator
        {
            get
            {
                return this.numerator;
            }

            set
            {
                this.numerator = value;
            }
        }

        public int Denominator
        {
            get
            {
                return this.denominator;
            }

            set
            {
                if (value == 0)
                {
                    throw new ArgumentOutOfRangeException("Denominator could not be equal to zero");
                }
                this.denominator = value;
            }
        }

        public double DecimalValue
        {
            get
            {
                return Math.Round((double)this.numerator / (double)this.denominator, 2);
            }
        }

        public static Fraction Simplify(Fraction f)
        {
            int tempNumerator = f.Numerator;
            int tempDenominator = f.Denominator;
            int temp = 0;

            while (tempNumerator != 0 && tempDenominator != 0)
            {
                temp = tempDenominator;
                tempDenominator %= tempNumerator;
                tempNumerator = temp;
            }

            int gcd = tempNumerator + tempDenominator;
            f.Numerator /= gcd;
            f.Denominator /= gcd;

            return f;
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            Fraction result = new Fraction();

            if (f1.Denominator == f2.Denominator)
            {
                result = new Fraction(f1.Numerator + f2.Numerator, f1.Denominator);
            }
            else
            {
                int resultNumerator = f1.Numerator * f2.Denominator +
                    f1.Denominator * f2.Numerator;

                int resultDenominator = f1.Denominator * f2.Denominator;

                result = new Fraction(resultNumerator, resultDenominator);
            }

            return result;
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            Fraction result = new Fraction();

            if (f1.Denominator == f2.Denominator)
            {
                result = new Fraction(f1.Numerator - f2.Numerator, f1.Denominator);
            }
            else
            {
                int resultNumerator = f1.Numerator * f2.Denominator -
                    f1.Denominator * f2.Numerator;

                int resultDenominator = f1.Denominator * f2.Denominator;

                result = new Fraction(resultNumerator, resultDenominator);
            }

            return result;
        }

        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            int resultNumerator = f1.Numerator * f2.Numerator;
            int resultDenominator = f1.Denominator * f2.Denominator;

            return new Fraction(resultNumerator, resultDenominator);
        }

        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            Fraction reciprocal = new Fraction(f2.Denominator, f2.Numerator);

            int resultNumerator = f1.Numerator * reciprocal.Numerator;
            int resultDenominator = f1.Denominator * reciprocal.Denominator;

            return new Fraction(resultNumerator, resultDenominator);
        }

        public override string ToString()
        {
            string result = String.Empty();

            if (this.Numerator == 1 && this.Numerator == this.Denominator)
            {
                result = "1";
            }
            else
            {
                result = this.Numerator + "/" + this.Denominator;
            }

            return result;
        }
    }
}
