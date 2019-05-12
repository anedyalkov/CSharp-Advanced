namespace _03.Miner
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static int playerRow;
        static int playerCol;
        static string[][] matrix;
        static bool isOutside;
        static bool isDead;
        static Queue<int[]> indexes;
        static int coalCounter;
        static int allcoals;
        //static bool IsFinished;

        public static void Main()
        {

            var size = int.Parse(Console.ReadLine());
            var commands = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
            //var rows = dimensions[0];
            //var cols = dimensions[1];

            matrix = new string[size][];
            GetMatrix(size);

            MovePlayer(commands);

            Console.WriteLine($"{allcoals} coals left. ({playerRow}, {playerCol})");

        }



        public static void MovePlayer(string[] commands)
        {
            foreach (var command in commands)
            {
                
                if (command == "up")
                {
                    Move(-1, 0);
                }
                else if (command == "down")
                {
                    Move(1, 0);
                }
                else if (command == "left")
                {
                    Move(0, -1);
                }
                else if (command == "right")
                {
                    Move(0, 1);
                }

                //SpreadBunnies();
                if (IsFinished())
                {
                    Console.WriteLine($"You collected all coals! ({playerRow}, {playerCol})");
                    Environment.Exit(0);
                }
                if (isOutside)
                {
                    continue;
                }

                if (isDead)
                {
                    Console.WriteLine($"Game over! ({playerRow}, {playerCol})");
                    Environment.Exit(0);
                    //break;
                }
            }
        }

        public static void Move(int row, int col)
        {
            int targetRow = playerRow + row;
            int targetCol = playerCol + col;

            if (!IsInside(targetRow, targetCol))
            {
                matrix[playerRow][playerCol] = "s";
                isOutside = true;
            }
            else if (IsCoal(targetRow, targetCol))
            {
                matrix[playerRow][playerCol] = "*";
                playerRow += row;
                playerCol += col;
                coalCounter++;
                allcoals--;
            }
            else if (IsE(targetRow, targetCol))
            {
                playerRow += row;
                playerCol += col;
                isDead = true;
            }
            else
            {
                matrix[playerRow][playerCol] = "*";

                playerRow += row;
                playerCol += col;

                matrix[playerRow][playerCol] = "s";
            }
        }
        public static bool IsFinished()
        {
            return allcoals == 0;
        }
        public static bool IsCoal(int targetRow, int targetCol)
        {
            return matrix[targetRow][targetCol] == "c";
        }
        public static bool IsE(int targetRow, int targetCol)
        {
            return matrix[targetRow][targetCol] == "e";
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

        public static void GetMatrix(int size)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                var input = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
                matrix[row] = new string[size];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = input[col];
                    if (matrix[row][col] == "s")
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    if (matrix[row][col] == "c")
                    {
                        allcoals++;
                    }
                }
            }
        }
    }
}
