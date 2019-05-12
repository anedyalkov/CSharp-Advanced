namespace _06.Target_Practice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var dimensions = Console.ReadLine().Split().ToArray();
            var rows = int.Parse(dimensions[0]);
            var cols = int.Parse(dimensions[1]);

            var str = Console.ReadLine();
            var shotParameteres = Console.ReadLine().Split().Select(int.Parse).ToArray();

            char[][] matrix = new char[rows][];

            GetMatrix(matrix, rows, cols, str);
            Shoot(matrix, shotParameteres);
            Collapse(matrix);
            PrintMatrix(matrix);
        }

        public static void Collapse(char[][] matrix)
        {
            Queue<char> elements = new Queue<char>();

            for (int col = 0; col < matrix[0].Length; col++)
            {
                int counter = 0;
                for (int row = 0; row < matrix.Length; row++)
                {
                    if (matrix[row][col] != ' ')
                    {
                        elements.Enqueue(matrix[row][col]);
                    }
                    else
                    {
                        counter++;
                    }
                }

                for (int row = 0; row < counter; row++)
                {
                    matrix[row][col] = ' ';
                }

                for (int row = counter; row < matrix.Length; row++)
                {
                    matrix[row][col] = elements.Dequeue();
                }
            }
        }

        public static void Shoot(char[][] matrix, int[] shotParameteres)
        {
            var targetRow = shotParameteres[0];
            var targetCol = shotParameteres[1];
            var radius = shotParameteres[2];

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    bool inside = Math.Pow((targetRow - row), 2) + Math.Pow((targetCol - col), 2) <= Math.Pow(radius, 2);

                    if (inside)
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }
        }

        public static void PrintMatrix(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        public static void GetMatrix(char[][] matrix, int rows, int cols, string str)
        {
            int counter = 0;
            bool isLeft = true;
            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                matrix[row] = new char[cols];

                if (isLeft)
                {                
                    for (int col = matrix[row].Length - 1; col >= 0; col--)
                    {
                        counter = SetLetter(matrix, str, counter, row, col);
                    }
                    isLeft = false;
                }
                else
                {                 
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        counter = SetLetter(matrix, str, counter, row, col);
                    }
                    isLeft = true;
                }
            }
        }

        public static int SetLetter(char[][] matrix, string str, int counter, int row, int col)
        {
            if (counter > str.Length - 1)
            {
                counter = 0;
            }
            matrix[row][col] = str[counter++];
            return counter;
        }
    }
}
