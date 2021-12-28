#include "Matrix.h"

Matrix::Matrix(int n) {
    matrixOrder = n;
    row = new double[matrixOrder];
    row[0] = rand() + static_cast<double>(rand()) / RAND_MAX + 1;
    for (auto i = 1; i < matrixOrder; i++) {
        row[i] = static_cast<double>(rand()) / RAND_MAX * 10 + 1;
    }
}

Matrix::Matrix() {
    printf("¬ведите пор€док матрицы: ");
    matrixOrder = 0;
    std::cin >> matrixOrder;

    row = new double[matrixOrder];

    for (int i = 0; i < matrixOrder; i++) {
		//std::cout << i << "${i}: ";
        std::cout << i << " element: ";
        std::cin >> row[i];
    }
}

Matrix::Matrix(int size, double* source) {

    matrixOrder = size;
    row = new double[matrixOrder];

    for (int i = 0; i < matrixOrder; i++) {
        row[i] = source[i];
    }
}

Matrix::Matrix(const Matrix& source) {

    matrixOrder = source.matrixOrder;
    row = new double[matrixOrder];

    for (int i = 0; i < matrixOrder; i++) {
        row[i] = source.row[i];
    }
}

Matrix::~Matrix() {
    delete[] row;
}

Matrix& Matrix::operator=(const Matrix& source) {

    if (row != source.row) {

        delete[] row;

        matrixOrder = source.matrixOrder;
        row = new double[matrixOrder];

        for (int i = 0; i < matrixOrder; i++) {
            row[i] = source.row[i];
        }
    }

    return *this;
}

void Matrix::Solve(double* leftPart, double* arrAnswers) {
    double* a = row;
    int m = matrixOrder;

    double* tempArrA = new double[m]; 
    double* tempArrB = new double[m]; 

    int j, k, kj;
    double rk, sk, fkk;

    tempArrA[0] = 1. / a[0];
    arrAnswers[0] = leftPart[0] * tempArrA[0];
    tempArrB[0] = 0.;
    for (k = 2; k <= m; ++k) {
        tempArrA[k - 1] = 0.;
        arrAnswers[k - 1] = 0.;
        rk = 0.;
        fkk = 0.;
        for (j = 2; j <= k; ++j) {
            kj = k - j + 1;
            tempArrB[j - 1] = tempArrA[kj - 1];
            rk += a[j - 1] * tempArrB[j - 1];
            fkk += a[j - 1] * arrAnswers[kj - 1];
        }
        fkk = leftPart[k - 1] - fkk;
        sk = 1. / (1. - rk * rk);
        rk = -rk * sk;
        for (j = 1; j <= k; ++j) {
            kj = k - j + 1;
            tempArrA[j - 1] = tempArrA[j - 1] * sk + tempArrB[j - 1] * rk;
            arrAnswers[kj - 1] += tempArrA[j - 1] * fkk;
        }
    }

    delete[] tempArrA;
    delete[] tempArrB;
}