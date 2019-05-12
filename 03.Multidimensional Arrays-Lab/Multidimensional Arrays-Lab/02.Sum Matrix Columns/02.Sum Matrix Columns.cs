namespace _02.Sum_Matrix_Columns
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
            PrintSumOfEachColumn(matrix,rows,cols);
        }

        public static int[,] GetMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            return matrix;
        }

        public static void PrintSumOfEachColumn(int[,] matrix,int rows,int cols)
        {
            var sum = 0;

            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    sum += matrix[row, col];
                }
                Console.WriteLine(sum);
                sum = 0;
            }
        }

        //public static void PrintMatrix(int[,] matrix)
        //{
        //    for (int row = 0; row < matrix.GetLength(0); row++)
        //    {
        //        for (int col = 0; col < matrix.GetLength(1); col++)
        //        {
        //            Console.Write(matrix[row, col] + " ");
        //        }
        //        Console.WriteLine();
        //    }
        //}
    }
}
