namespace _04.Maximal_Sum
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            var rows = int.Parse(input[0]);
            var cols = int.Parse(input[1]);

            int[,] matrix = GetMatrix(rows, cols);

            PrintSquare3x3(matrix, rows, cols);
        }

        public static void PrintSquare3x3(int[,] matrix, int rows, int cols)
        {
            var maxValue = int.MinValue;

            string firstRow = string.Empty;
            string secondRow = string.Empty;
            string thirdRow = string.Empty;

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    var currentValue = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                        + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                        + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currentValue > maxValue)
                    {
                        maxValue = currentValue;
                        firstRow = matrix[row, col].ToString() + " " + matrix[row, col + 1].ToString() + " " + matrix[row, col + 2].ToString();
                        secondRow = matrix[row + 1, col].ToString() + " " + matrix[row + 1, col + 1].ToString() + " " + matrix[row + 1, col + 2].ToString();
                        thirdRow = matrix[row + 2, col].ToString() + " " + matrix[row + 2, col + 1].ToString() + " " + matrix[row + 2, col + 2].ToString();

                    }
                }
            }
            Console.WriteLine($"Sum = {maxValue}");
            Console.WriteLine(firstRow);
            Console.WriteLine(secondRow);
            Console.WriteLine(thirdRow);
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
    }
}
