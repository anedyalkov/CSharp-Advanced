namespace _03.Squares_in_Matrix
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var size = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

            var rows = int.Parse(size[0]);
            var cols = int.Parse(size[1]);

            char[,] matrix = GetMatrix(rows, cols);
            GetSquaresWithEqualChars(matrix, rows, cols);

        }

        public static void GetSquaresWithEqualChars(char[,] matrix, int rows, int cols)
        {
            
            var count = 0;
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    var topLeft = matrix[row,col];
                    var topRight = matrix[row,col + 1];
                    var bottomLeft = matrix[row + 1,col];
                    var bottomRight = matrix[row + 1,col + 1];

                    if (topLeft == topRight && topLeft == bottomLeft && topLeft == bottomRight)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }

        public static char[,] GetMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = char.Parse(line[col]);
                }
            }
            return matrix;
        }
    }
}
