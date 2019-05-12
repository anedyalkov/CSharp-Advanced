namespace _04.Symbol_in_Matrix
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var size = int.Parse(Console.ReadLine());
          
            char[,] matrix = GetMatrix(size);

            //PrintMatrix(matrix, size);

            PrintThePositionOfSymbol(matrix, size);

        }

        public static void PrintThePositionOfSymbol(char[,] matrix, int size)
        {
            var inputChar = Console.ReadLine().ToCharArray();
            var symbol = inputChar[0];
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row,col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{symbol} does not occur in the matrix");
        }

        public static char[,] GetMatrix(int size)
        {
            char[,] matrix = new char[size, size];
            for (int row = 0; row < size; row++)
            {
                var line = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            return matrix;
        }

        //public static void PrintMatrix(char[,] matrix, int size)
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
