using System;
using System.Text;

namespace just_try
{
    public class Matrix
    {
        public int MatrixOrder { get; }
        public double[] row;

        //инициализация радномными значениями
        public Matrix(int n)
        {
            Random rnd = new Random();

            MatrixOrder = n;
            row = new double[MatrixOrder];
            row[0] = rnd.NextDouble() * 10000 + 1000;

            for(int i = 1; i < MatrixOrder; i++)
            {
                row[i] = rnd.NextDouble() * 10 + 1;
            }
        }

        //инициализация с консоли
        public Matrix()
        {
            Random rnd = new Random();
            Console.Write("Enter matrix size: ");
            MatrixOrder = Convert.ToInt32(Console.ReadLine());
            row = new double[MatrixOrder];

            for (int i = 0; i < MatrixOrder; i++)
            {
                Console.Write($"{i} element: ");
                row[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        // инициализация с передаваемого массива
        public Matrix(int size, double[] source)
        {
            MatrixOrder = size;
            row = new double[MatrixOrder];
            for (int i = 0; i < MatrixOrder; i++)
            {
                row[i] = source[i];
            }
        }

        public void Solve(double[] leftPart, double[] arrAnswers)
        {
            int MyMatr = MatrixOrder;
            double[] a1 = new double[MyMatr];
            double[] b1 = new double[MyMatr];

            int j, k, kj;
            double rk, sk, fkk;

            a1[0] = 1 / row[0];
            arrAnswers[0] = leftPart[0] * a1[0];
            b1[0] = 0;
            for (k = 2; k <= MyMatr; ++k)
            {
                a1[k - 1] = 0;
                arrAnswers[k - 1] = 0;
                rk = 0;
                fkk = 0;
                for (j = 2; j <= k; ++j)
                {
                    kj = k - j + 1;
                    b1[j - 1] = a1[kj - 1];
                    rk += row[j - 1] * b1[j - 1];
                    fkk += row[j - 1] * arrAnswers[kj - 1];
                }
                fkk = leftPart[k - 1] - fkk;
                sk = 1 / (1 - rk * rk);
                rk = -rk * sk;
                for (j = 1; j <= k; ++j)
                {
                    kj = k - j + 1;
                    a1[j - 1] = a1[j - 1] * sk + b1[j - 1] * rk;
                    arrAnswers[kj - 1] += a1[j - 1] * fkk;
                }
            }
        }

        private double GetElement(int i, int j)
        {
            return row[Math.Abs(i - j)];
        }

        public override string ToString()
        {
            StringBuilder myStr = new StringBuilder();
            for (int i = 0; i < MatrixOrder; i++)
            {
                for (int j = 0; j < MatrixOrder; j++)
                    myStr.Append($"{GetElement(i, j):f4}");       
            }

            return myStr.ToString();
        }

        
    }
}