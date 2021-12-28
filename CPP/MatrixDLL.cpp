#include "Matrix.h"

extern "C" __declspec(dllexport) double SolveRepeatCPP(int, int);
extern "C" __declspec(dllexport) void SolveMatrixCPP(int, double*, double*, double*);

double SolveRepeatCPP(int matrixOrder, int repetition) {
	Matrix matrix(matrixOrder);
	auto rightPart = new double[matrixOrder]; // right part
	auto arrAnswers = new double[matrixOrder]; 
	for (auto i = 0; i < matrixOrder; i++) rightPart[i] = rand() % 11 + static_cast<double>(rand()) / RAND_MAX;

	auto start = clock();
	for (auto i = 0; i < repetition; i++) {
		matrix.Solve(rightPart, arrAnswers);
	}
	auto stop = clock();
	
	delete[] rightPart;
	delete[] arrAnswers;

	return (static_cast<double>(stop) - start) * 1000 / CLOCKS_PER_SEC;
}

void SolveMatrixCPP(int matrixOrder, double* sourceMatrix, double* right, double* ans) {
	Matrix matrix(matrixOrder, sourceMatrix);
	matrix.Solve(right, ans);
}