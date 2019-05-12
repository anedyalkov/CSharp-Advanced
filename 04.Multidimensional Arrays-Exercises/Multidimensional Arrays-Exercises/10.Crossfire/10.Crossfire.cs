namespace _10.Crossfire
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static List<List<int>> matrix;

        public static void Main()
        {
            var input = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

            var rows = int.Parse(input[0]);
            var cols = int.Parse(input[1]);

            matrix = new List<List<int>>();


            GetMatrix(rows, cols);
            DestroyCells();
            PrintMatrix();
        }

        public static void DestroyCells()
        {
            string input;
            while ((input = Console.ReadLine()) != "Nuke it from orbit")
            {
                var commands = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var targetRow = commands[0];
                var targetCol = commands[1];
                var radius = commands[2];

                for (int row = targetRow - radius; row <= targetRow + radius; row++)
                {
                    if (IsInside(row, targetCol))
                    {
                        matrix[row][targetCol] = 0;
                    }
                }

                for (int col = targetCol - radius; col <= targetCol + radius; col++)
                {
                    if (IsInside(targetRow, col))
                    {
                        matrix[targetRow][col] = 0;
                    }
                }

                for (int row = 0; row < matrix.Count; row++)
                {
                    matrix[row].RemoveAll(n => n == 0);

                    if (matrix[row].Count == 0)
                    {
                        matrix.RemoveAt(row);
                        row--;
                    }
                }
            }

        }

        public static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.Count && col >= 0 && col < matrix[row].Count;
        }

        public static void PrintMatrix()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        public static void GetMatrix(int rows, int cols)
        {
            var count = 1;
            for (int row = 0; row < rows; row++)
            {
                matrix.Add(new List<int>());

                for (int col = 0; col < cols; col++)
                {
                    matrix[row].Add(count);
                    count++;
                }
            }
        }
    }
}

