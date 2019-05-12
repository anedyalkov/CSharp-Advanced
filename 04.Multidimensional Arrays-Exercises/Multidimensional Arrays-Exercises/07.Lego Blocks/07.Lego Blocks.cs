namespace _07.Lego_Blocks
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var size = int.Parse(Console.ReadLine());

            int[][] firstMatrix = new int[size][];
            int[][] secondtMatrix = new int[size][];
            int[][] matchedMatrix = new int[size][];

            GetFirstMatrix(firstMatrix,size);
            GetSecondtMatrix(secondtMatrix,size);
            ReverseSecondMatrix(secondtMatrix);
            MatchMatrixs(firstMatrix, secondtMatrix, matchedMatrix);
            ChecKMatchedMatrix(matchedMatrix);

        }

        public static void ChecKMatchedMatrix(int[][] matchedMatrix)
        {
            bool isRectangularMatrix = false;
            for (int row = 0; row < matchedMatrix.Length - 1; row++)
            {
                if (matchedMatrix[row].Length == matchedMatrix[row + 1].Length)
                {
                    isRectangularMatrix = true;
                }
                else
                {
                    isRectangularMatrix = false;
                    break;
                }
            }
            if (isRectangularMatrix)
            {
                foreach (var row in matchedMatrix)
                {
                    Console.WriteLine($"[{string.Join(", ",row)}]");
                }
            }
            else
            {
                var totalCells = 0;

                foreach (var row in matchedMatrix)
                {
                    totalCells += row.Length;
                }

                Console.WriteLine($"The total number of cells is: {totalCells}");
            }
        }

        public static void MatchMatrixs(int[][] firstMatrix, int[][] secondtMatrix, int[][] matchedMatrix)
        {
            for (int row = 0; row < matchedMatrix.Length; row++)
            {
                matchedMatrix[row] = firstMatrix[row].Concat(secondtMatrix[row]).ToArray();
            }
        }

        public static void ReverseSecondMatrix(int[][] secondtMatrix)
        {
            for (int row = 0; row < secondtMatrix.Length; row++)
            {
                secondtMatrix[row] = secondtMatrix[row].Reverse().ToArray();
            }
        }

        public static void GetSecondtMatrix(int[][] secondtMatrix, int size)
        {         
            for (int i = 0; i < size; i++)
            {
                secondtMatrix[i] = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
        }

        public static void GetFirstMatrix(int[][] firstMatrix,int size)
        {
            for (int i = 0; i < size; i++)
            {
                firstMatrix[i] = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
        }
    }
}
