namespace _01.Matrix_of_Palindromes
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().ToArray();

            var rows = int.Parse(input[0]);
            var cols = int.Parse(input[1]);

            string[,] matrix = GetMatrix(rows, cols);
            PrintMatrix(matrix,rows,cols);

        }

        public static void PrintMatrix(string[,] matrix,int rows,int cols)
        {
            for (int row = 0; row < rows; row++)
            {
               
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }

        public static string[,] GetMatrix(int rows, int cols)
        {
            string[,] matrix = new string[rows, cols];
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int row = 0; row < rows; row++)
            {
                var firstChar = alphabet[row];
                for (int col = 0; col < cols; col++)
                {
                    if (col == 0)
                    {
                        matrix[row, col] = alphabet[row].ToString() + alphabet[row].ToString() + alphabet[row].ToString();
                    }
                    else
                    {
                        matrix[row, col] = alphabet[row].ToString() + alphabet[col + row].ToString() + alphabet[row].ToString();
                    }                  
                }
            }

            return matrix;
        }
    }
}
