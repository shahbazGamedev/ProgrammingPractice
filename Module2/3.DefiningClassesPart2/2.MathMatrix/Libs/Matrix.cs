namespace MathMatrix.Libs
{
    using System;
    using System.Text;

    public class Matrix
    {
        public Matrix(int rows, int cols)
        {
            this.Elements = new int[rows, cols];
        }

        public int[,] Elements { get; set; }

        public static Matrix operator +(Matrix first, Matrix second)
        {
            if (!first.Equals(second))
            {
                throw new ArgumentOutOfRangeException("Matrices should be of equal sizes in order to be added.");
            }

            Matrix result = new Matrix(first.Elements.GetLength(0), first.Elements.GetLength(1));
            for (int i = 0; i < first.Elements.GetLength(0); i++)
            {
                for (int j = 0; j < first.Elements.GetLength(1); j++)
                {
                    result.Elements[i, j] = first.Elements[i, j] + second.Elements[i, j];
                }
            }

            return result;
        }

        public static Matrix operator -(Matrix first, Matrix second)
        {
            if (!first.Equals(second))
            {
                throw new ArgumentOutOfRangeException("Matrices should be of equal sizes in order to be added.");
            }

            Matrix result = new Matrix(first.Elements.GetLength(0), first.Elements.GetLength(1));
            for (int i = 0; i < first.Elements.GetLength(0); i++)
            {
                for (int j = 0; j < first.Elements.GetLength(1); j++)
                {
                    result.Elements[i, j] = first.Elements[i, j] - second.Elements[i, j];
                }
            }

            return result;
        }

        public static Matrix operator *(Matrix first, Matrix second)
        {
            if (first.Elements.GetLength(0) != second.Elements.GetLength(1))
            {
                throw new ArgumentOutOfRangeException("First matrix should have rows equal to the second matrix'" +
                "columns in order to perform multiplication.");
            }

            Matrix result = new Matrix(first.Elements.GetLength(0), second.Elements.GetLength(1));

            for (int i = 0; i < first.Elements.GetLength(0); i++)
            {
                for (int j = 0; j < second.Elements.GetLength(1); j++)
                {
                    int sum = 0;

                    for (int k = 0; k < second.Elements.GetLength(0); k++)
                    {
                        sum += first.Elements[i, k] * second.Elements[k, j];
                    }

                    result.Elements[i, j] = sum;
                }
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < this.Elements.GetLength(0); i++)
            {
                if (i != 0)
                {
                    result.Append("\n");
                }

                for (int j = 0; j < this.Elements.GetLength(1); j++)
                {
                    if (this.Elements[i, j] >= 0 && this.Elements[i, j] < 10)
                    {
                        result.AppendFormat("  {0}  ", this.Elements[i, j]);
                    }
                    else
                    {
                        result.AppendFormat(" {0} ", this.Elements[i, j]);
                    }
                }
            }

            return result.ToString();
        }

        public override bool Equals(object obj)
        {
            bool result = false;

            if (obj == null)
            {
                result = false;
            }

            Matrix second = obj as Matrix;
            if ((Object)second == null)
            {
                result = false;
            }

            bool equalNumberOfRows = this.Elements.GetLength(0) == second.Elements.GetLength(0);
            bool equalNumberOfCols = this.Elements.GetLength(1) == second.Elements.GetLength(1);
            result = (equalNumberOfRows && equalNumberOfCols);

            return result;
        }

        public override int GetHashCode()
        {
            return this.Elements[0, 0];
        }
    }
}
