using System;
using System.Collections.Generic;

namespace WorkWithGraphsLibrary
{
    public static class MatrixExtension
    {
        public static bool IsSymmetric(this int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
                for (int j = i + 1; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] != matrix[j, i]) return false;
            return true;
        }

        public static int[,] MatrixSubstract(this int[,] matrix1, int[,] matrix2)
        {
            int[,] result_matrix = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
            for (int i = 0; i < matrix1.GetLength(0); i++)
                for (int j = 0; j < matrix1.GetLength(1); j++)
                    result_matrix[i, j] = matrix1[i, j] - matrix2[i, j];
            return result_matrix;
        }
    }
}
