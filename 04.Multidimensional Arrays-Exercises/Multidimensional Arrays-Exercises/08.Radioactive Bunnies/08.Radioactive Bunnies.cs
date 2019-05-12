namespace _08.Radioactive_Bunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static int playerRow;
        static int playerCol;
        static char[][] matrix;
        static bool isOutside;
        static bool isDead;
        static Queue<int[]> indexes;

        public static void Main()
        {
            var dimensions = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var rows = dimensions[0];
            var cols = dimensions[1];

            matrix = new char[rows][];
            GetMatrix(rows, cols);
            

            var commands = Console.ReadLine();

            MovePlayer(commands);            
        }

        public static void SpreadBunnies()
        {
            indexes = new Queue<int[]>();
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'B')
                    {
                        indexes.Enqueue(new int[] { row,col});
                    }
                }
            }
            while (indexes.Count > 0)
            {
                var currentIndex = indexes.Dequeue();
                var targetRow = currentIndex[0];
                var targetCol = currentIndex[1];

                if (IsInside(targetRow - 1, targetCol))
                {
                    if (IsPlayer(targetRow - 1,targetCol))
                    {
                        isDead = true;
                    }
                    matrix[targetRow - 1][targetCol] = 'B';
                }

                if (IsInside(targetRow + 1, targetCol))
                {
                    if (IsPlayer(targetRow + 1, targetCol))
                    {
                        isDead = true;
                    }
                    matrix[targetRow + 1][targetCol] = 'B';
                }

                if (IsInside(targetRow, targetCol - 1))
                {
                    if (IsPlayer(targetRow, targetCol - 1))
                    {
                        isDead = true;
                    }
                    matrix[targetRow][targetCol - 1] = 'B';
                }

                if (IsInside(targetRow, targetCol + 1))
                {
                    if (IsPlayer(targetRow, targetCol + 1))
                    {
                        isDead = true;
                    }
                    matrix[targetRow][targetCol + 1] = 'B';
                }
            }
           

        }

        private static bool IsPlayer(int row, int col)
        {
            return matrix[row][col] == 'P';
        }

        public static void MovePlayer(string commands)
        {
            foreach (var command in commands)
            {
                if (command == 'U')
                {
                    Move(-1, 0);
                }
                else if (command == 'D')
                {
                    Move(1, 0);
                }
                else if (command == 'L')
                {
                    Move(0, -1);
                }
                else if (command == 'R')
                {
                    Move(0, 1);
                }

                SpreadBunnies();
                if (isOutside)
                {
                    PrintMatrix();
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    Environment.Exit(0);
                    //break;
                }

                if (isDead)
                {
                    PrintMatrix();
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    Environment.Exit(0);
                    //break;
                }
            }
        }

        public static void Move(int row, int col)
        {
            int targetRow = playerRow + row;
            int targetCol = playerCol + col;

            if (!IsInside(targetRow,targetCol))
            {
                matrix[playerRow][playerCol] = '.';
                isOutside = true;
            }
            else if (IsBunny(targetRow,targetCol))
            {
                matrix[playerRow][playerCol] = '.';
                playerRow += row ;
                playerCol += col;
                isDead = true;
            }
            else
            {
                matrix[playerRow][playerCol] = '.';

                playerRow += row;
                playerCol += col;

                matrix[playerRow][playerCol] = 'P';
            }
        }

        public static bool IsBunny(int targetRow, int targetCol)
        {
            return matrix[targetRow][targetCol] == 'B';
        }

        public static bool IsInside(int row, int col)
        {
            bool isInside = row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length; 
            return isInside;
        }

        public static void PrintMatrix()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        public static void GetMatrix(int rows, int cols)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                var input = Console.ReadLine();
                matrix[row] = new char[cols];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = input[col];
                    if (matrix[row][col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }
    }
}
