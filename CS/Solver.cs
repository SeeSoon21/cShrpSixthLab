using System;
using System.Diagnostics;

namespace just_try
{
	class Solver
	{
		public static long SolveRepeatCS(int matrixOrder, int repetition)
		{
			Random rnd = new Random();
			Matrix matrix = new Matrix(matrixOrder);
            double[] rightPart = new double[matrixOrder];
            double[] arrAnswers = new double[matrixOrder]; 

			for (var i = 0; i < matrixOrder; i++)
                rightPart[i] = rnd.NextDouble() * 10;

            Stopwatch timer = new Stopwatch();
			timer.Start();

			for (var i = 0; i < repetition; i++)
				matrix.Solve(rightPart, arrAnswers);
			

			timer.Stop();

			return timer.ElapsedMilliseconds;

		}

		public static void SolveMatrixCS(int matrixOrder, double[] sourceMatrix, double[] right, double[] ans)
		{
			var matrix = new Matrix(matrixOrder, sourceMatrix);
			matrix.Solve(right, ans);
		}
	}


}
