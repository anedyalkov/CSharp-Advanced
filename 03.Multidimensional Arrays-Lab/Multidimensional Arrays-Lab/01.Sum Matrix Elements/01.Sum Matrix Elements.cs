namespace _01.Sum_Matrix_Elements
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            var rows = int.Parse(input[0]);
            var cols = int.Parse(input[1]);

            int[,] matrix = GetMatrix(rows, cols);
            //PrintMatrix(matrix);

            int sum = GetSum(matrix);

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }

        public static int[,] GetMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            return matrix;
        }

        public static int GetSum(int[,] matrix)
        {
            var sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sum += matrix[row, col];
                }
            }

            return sum;
        }

        //public static void PrintMatrix(int[,] matrix)
        //{
        //    for (int row = 0; row < matrix.GetLength(0); row++)
        //    {
        //        for (int col = 0; col < matrix.GetLength(1); col++)
        //        {
        //            Console.Write(matrix[row,col] + " ");
        //        }
        //        Console.WriteLine();
        //    }
        //}
    }
}
