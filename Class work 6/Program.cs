﻿using System;


class Matrix
{
    public int[,] data;

    public Matrix(int rows, int cols)
    {
        data = new int[rows, cols];
    }

    public int Rows
    {
        get { return data.GetLength(0); }
    }

    public int Columns
    {
        get { return data.GetLength(1); }
    }

    public int this[int row, int col]
    {
        get { return data[row, col]; }
        set { data[row, col] = value; }
    }

    public static Matrix operator +(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
            throw new ArgumentException("Matrices must have the same dimensions.");

        Matrix result = new Matrix(matrix1.Rows, matrix1.Columns);

        for (int i = 0; i < matrix1.Rows; i++)
        {
            for (int j = 0; j < matrix1.Columns; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }

        return result;
    }

    public static Matrix operator -(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
            throw new ArgumentException("Matrices must have the same dimensions.");

        Matrix result = new Matrix(matrix1.Rows, matrix1.Columns);

        for (int i = 0; i < matrix1.Rows; i++)
        {
            for (int j = 0; j < matrix1.Columns; j++)
            {
                result[i, j] = matrix1[i, j] - matrix2[i, j];
            }
        }

        return result;
    }

    public static Matrix operator *(Matrix matrix, int scalar)
    {
        Matrix result = new Matrix(matrix.Rows, matrix.Columns);

        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Columns; j++)
            {
                result[i, j] = matrix[i, j] * scalar;
            }
        }

        return result;
    }

    public bool Equals(Matrix otherMatrix)
    {
        if (this.Rows != otherMatrix.Rows || this.Columns != otherMatrix.Columns)
            return false;

        for (int i = 0; i < this.Rows; i++)
        {
            for (int j = 0; j < this.Columns; j++)
            {
                if (this[i, j] != otherMatrix[i, j])
                    return false;
            }
        }

        return true;
    }

    public static bool operator ==(Matrix matrix1, Matrix matrix2)
    {
        return matrix1.Equals(matrix2);
    }

    public static bool operator !=(Matrix matrix1, Matrix matrix2)
    {
        return !matrix1.Equals(matrix2);
    }
}

class Program
{
    static void Main()
    {
  
        Matrix matrix1 = new Matrix(2, 3);
        matrix1[0, 0] = 1; matrix1[0, 1] = 2; matrix1[0, 2] = 3;
        matrix1[1, 0] = 4; matrix1[1, 1] = 5; matrix1[1, 2] = 6;

        Matrix matrix2 = new Matrix(2, 3);
        matrix2[0, 0] = 7; matrix2[0, 1] = 8; matrix2[0, 2] = 9;
        matrix2[1, 0] = 10; matrix2[1, 1] = 11; matrix2[1, 2] = 12;

        Matrix resultSum = matrix1 + matrix2;
        Matrix resultSubtract = matrix1 - matrix2;

        Console.WriteLine("Matrix 1:");
        PrintMatrix(matrix1);
        Console.WriteLine("\nMatrix 2:");
        PrintMatrix(matrix2);
        Console.WriteLine("\nMatrix 1 + Matrix 2:");
        PrintMatrix(resultSum);
        Console.WriteLine("\nMatrix 1 - Matrix 2:");
        PrintMatrix(resultSubtract);

        if (matrix1 == matrix2)
            Console.WriteLine("\nMatrices are equal.");
        else
            Console.WriteLine("\nMatrices are not equal.");

        Console.ReadKey();
    }

    static void PrintMatrix(Matrix matrix)
    {
        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Columns; j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}