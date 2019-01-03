using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class filling
    {
        public int Rank(double[,] matrix) //считаем ранг
        {
            int rang = 0;
            int q = 1;
            while (q <= MinValue(matrix.GetLength(0), matrix.GetLength(1)))
            {
                double[,] matbv = new double[q, q];
                for (int i = 0; i < (matrix.GetLength(0) - (q - 1)); i++)
                {
                    for (int j = 0; j < (matrix.GetLength(1) - (q - 1)); j++)
                    {
                        for (int k = 0; k < q; k++)
                        {
                            for (int c = 0; c < q; c++)
                            {
                                matbv[k, c] = matrix[i + k, j + c];
                            }
                        }

                        if (Determ(matbv) != 0)
                        {
                            rang = q;
                        }
                    }
                }
                q++;
            }
            return rang;
        }
        public static double Determ(double[,] matrix) //считаем определитель
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) throw new Exception(" Число строк в матрице не совпадает с числом столбцов");
            double det = 0;
            int Rank = matrix.GetLength(0);
            if (Rank == 1) det = matrix[0, 0];
            if (Rank == 2) det = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            if (Rank > 2)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    det += Math.Pow(-1, 0 + j) * matrix[0, j] * Determ(GetMinor(matrix, 0, j));
                }
            }
            return det;
        }
        public static double[,] GetMinor(double[,] matrix, int row, int column) //получаем минор
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) throw new Exception(" Число строк в матрице не совпадает с числом столбцов");
            double[,] buf = new double[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i != row) || (j != column))
                    {
                        if (i > row && j < column) buf[i - 1, j] = matrix[i, j];
                        if (i < row && j > column) buf[i, j - 1] = matrix[i, j];
                        if (i > row && j > column) buf[i - 1, j - 1] = matrix[i, j];
                        if (i < row && j < column) buf[i, j] = matrix[i, j];
                    }
                }
            return buf;
        }
        private int MinValue(int a, int b) //мин значение
        {
            if (a >= b)
                return b;
            else
                return a;
        }
        public static double[,] Multiplication(double[,] a, double[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
            double[,] r = new double[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return r;
        }
        public double[,] MatrU(double[,] A, double[,] b, int n, int colB)
        {
            double[,] U = new double[n, n * colB];
            double[,] vr = new double[n, colB];
            double[,] vr1 = new double[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    vr1[i, j] = A[i, j];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < colB; j++)
                    U[i, j] = b[i, j];
            for (int j = 1; j < n; j++)
            {
                vr = filling.Multiplication(vr1, b);
                for (int k = 0; k < colB; k++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        U[i, j * colB + k] = vr[i, k];
                    }
                }
                vr1 = filling.Multiplication(vr1, A);
            }
            return U;
        }
        public double[,] MatrN(double[,] A, double[,] c, int n, int colC)
        {
            double[,] N = new double[n * colC, n];
            double[,] vr = new double[colC, n];
            double[,] vr1 = new double[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    vr1[i, j] = A[i, j];
            for (int i = 0; i < colC; i++)
                for (int j = 0; j < n; j++)
                    N[i, j] = c[i, j];
            for (int j = 1; j < n; j++)
            {
                vr = filling.Multiplication(c, vr1);
                for (int k = 0; k < colC; k++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        N[j * colC + k, i] = vr[k, i];
                    }
                }
                vr1 = filling.Multiplication(vr1, A);
            }
            return N;
        }



    }
}
