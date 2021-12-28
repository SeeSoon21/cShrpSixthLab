using System;
using System.IO;
using System.Runtime.InteropServices;

namespace just_try
{
    class Program
    {
        [DllImport(@"CPP.dll")]
        public static extern double SolveRepeatCPP(int matrixOrder, int repetitionCount);

        [DllImport(@"CPP.dll")]
        public static extern void SolveMatrixCPP(int matrixOrder, double[] sourceMatrix, double[] right, double[] ans);


        static void Main(string[] args)
        {


            #region Test

            double[] rightTest = new double[6] { 21, 17, 15, 15, 17, 21 };
            double[] testMatrix = new double[] { 1, 2, 3, 4, 5, 6 };
            double[] x = new double[6] { 0, 0, 0, 0, 0, 0 };

            // C# test
            var test = new Matrix(6, testMatrix);
            test.Solve(rightTest, x);
            Console.WriteLine("Решение C# для тестовой матрицы(==1)");
            foreach (var i in x)
            {
                Console.WriteLine($"{i:f4}");
            }

            // C++ test
            SolveMatrixCPP(6, testMatrix, rightTest, x);
            Console.WriteLine("Решение C++ для тестовой матрицы(==1)");
            foreach (var i in x)
            {
                Console.WriteLine($"{i:f4}");
            }

            #endregion

       
            var times = new TimesList();
            Console.WriteLine("Введите имя файла: ");
            string filename;
            do
            {
                filename = Console.ReadLine();
            } while (filename.Length == 0);

            try
            {
                var fileInfo = new FileInfo(filename);
                if (fileInfo.Exists)
                {
                    times.Load(filename);
                    Console.WriteLine(times);
                }
                else
                {
                    Console.WriteLine("Файл не был найден. Создание файла...");
                    fileInfo.Create().Close();
                }

                var command = "1";
                while (command == "1")
                {
                    Console.WriteLine("Введите '1' для того, чтобы ввести порядок матрицы и число повторов. " +
                        "Любой другой ввод – выход.");
                    command = Console.ReadLine();
                    if (command != "1") break;

                    Console.Write("Введите порядок матрицы: ");
                    var matrixOrder = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Введите порядок повторения: ");
                    var repetitionsNumber = Convert.ToInt32(Console.ReadLine());

                    // расчёты C# 
                    var CSTime = Solver.SolveRepeatCS(matrixOrder, repetitionsNumber);

                    // расчёты C++
                    var CPPTime = SolveRepeatCPP(matrixOrder, repetitionsNumber);

                    times.Add(new TimeItem(matrixOrder, repetitionsNumber, CSTime, CPPTime));

                }

                Console.WriteLine("Окончательные измерения: ");
                Console.WriteLine(times);
                times.Save(filename);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}