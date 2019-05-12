namespace _05.Square_With_Maximum_Sum
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

            PrintSquare(matrix,rows,cols);
        }

        public static void PrintSquare(int[,] matrix, int rows, int cols)
        {
            var maxValue = int.MinValue;

            string firstRow = string.Empty;
            string secondRow = string.Empty;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    var currentValue = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (currentValue > maxValue)
                    {
                        maxValue = currentValue;
                        firstRow = matrix[row, col].ToString() + " " + matrix[row, col + 1].ToString();
                        secondRow = matrix[row + 1, col].ToString() + " " + matrix[row + 1, col + 1].ToString();
                    }
                }             
            }

            Console.WriteLine(firstRow);
            Console.WriteLine(secondRow);
            Console.WriteLine(maxValue);
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
    }
}
