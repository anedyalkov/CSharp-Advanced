namespace _02.Diagonal_Difference
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var size = int.Parse(Console.ReadLine());

            int[,] matrix = GetMatrix(size);
            int primaryDiagonalSum = SumPrimaryDiagonal(matrix, size);
            int secondaryDiagonalSum = SumSecondaryDiagonal(matrix, size);
            PrintResult(primaryDiagonalSum, secondaryDiagonalSum);
            //PrintMatrix(matrix,size);
        }

        public static void PrintResult(int primaryDiagonalSum, int secondaryDiagonalSum)
        {
            Console.WriteLine(Math.Abs(primaryDiagonalSum - secondaryDiagonalSum));
        }

        public static int SumSecondaryDiagonal(int[,] matrix, int size)
        {
            var sum = 0;
            for (int row = 0; row < size; row++)
            {
                sum += matrix[row, size - 1 - row];
            }
            return sum;
        }

        public static int SumPrimaryDiagonal(int[,] matrix, int size)
        {
            var sum = 0;
            for (int row = 0; row < size; row++)
            {
                sum += matrix[row, row];
            }
            return sum;
        }

        //public static void PrintMatrix(int[,] matrix, int size)
        //{
        //    for (int row = 0; row < size; row++)
        //    {

        //        for (int col = 0; col < size; col++)
        //        {
        //            Console.Write(matrix[row, col] + " ");
        //        }
        //        Console.WriteLine();
        //    }
        //}

        public static int[,] GetMatrix(int size)
        {
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                var line = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = line[col];
                }
            }
            return matrix;
        }
    }
}
