namespace _09.MovePlayer
{
    using System;
    using System.Linq;

    public class Program
    {
        static char[][] jaggedArray;
        static int playerRow;
        static int playerCol;

        public static void Main()
        {
            var input = Console.ReadLine().Split().ToArray();
            var rows = int.Parse(input[0]);
            var cols = int.Parse(input[1]);

           jaggedArray = new char[rows][];

            GetJaggedArray(rows, cols);
            MoveDownPlayer();
            PrintJaggedArray();
        }

        public static void MoveDownPlayer()
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (jaggedArray[row][col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            for (int row = playerRow; row < jaggedArray.Length; row++)
            {
                if (row % 2 == 1)
                {
                    MoveRight(row);
                }
                else
                {
                    MoveLeft(row);
                }              
            }
        }

        public static void MoveLeft(int row)
        {
            for (int col = jaggedArray[row].Length - 1; col >= 0; col--)
            {
                if (jaggedArray[row][col] == 'P')
                {
                    if (IsInSide(row, col - 1))
                    {
                        jaggedArray[row][col] = '.';
                        jaggedArray[row][col - 1] = 'P';
                    }
                }
            }

            if (IsInSide(row + 1,0))
            {
                jaggedArray[row][0] = '.';
                jaggedArray[row + 1][0] = 'P';
            }
        }

        public static void MoveRight(int row)
        {
            for (int col = 0; col < jaggedArray[row].Length; col++)
            {
                if (jaggedArray[row][col] == 'P')
                {
                    if (IsInSide(row, col + 1))
                    {
                        jaggedArray[row][col] = '.';
                        jaggedArray[row][col + 1] = 'P';
                    }

                }
            }

            if (IsInSide(row + 1,jaggedArray[row].Length - 1))
            {
                jaggedArray[row][jaggedArray[row].Length - 1] = '.';
                jaggedArray[row + 1][jaggedArray[row].Length - 1] = 'P';
            }
        }

        public static bool IsInSide(int row, int col)
        {
            return row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray[row].Length;
        }


        public static void PrintJaggedArray()
        {
            foreach (var row in jaggedArray)
            {
                Console.WriteLine(string.Join(string.Empty,row));
            }
        }

        public static void GetJaggedArray(int rows, int cols)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                var line = Console.ReadLine().ToCharArray();
                jaggedArray[row] = line;
            }
        }
    }
}
