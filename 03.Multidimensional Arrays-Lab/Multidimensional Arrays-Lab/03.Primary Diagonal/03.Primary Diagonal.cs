namespace _03.Primary_Diagonal
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var size = int.Parse(Console.ReadLine());

            int[,] matrix = GetMatrix(size);

            //PrintMatrix(matrix,size);

            int sum = SumOfMatrixPrimaryDiagonal(matrix, size);

            Console.WriteLine(sum);
        }

        public static int SumOfMatrixPrimaryDiagonal(int[,] matrix, int size)
        {
            var sum = 0;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < 1; col++)
                {
                    var currentNumber = matrix[row, col + row];
                    sum += currentNumber;
                }
            }

            return sum;
        }

        public static int[,] GetMatrix(int size)
        {
            int[,] matrix = new int[size, size];
            for (int row = 0; row < size; row++)
            {
                var line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            return matrix;
        }

        //public static void PrintMatrix(int[,] matrix,int size)
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
    }
}
