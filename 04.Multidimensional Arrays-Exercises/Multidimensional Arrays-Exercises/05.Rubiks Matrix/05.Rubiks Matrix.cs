namespace _05.Rubiks_Matrix
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                  .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToArray();
            var commandsNumber = int.Parse(Console.ReadLine());

            var rows = input[0];
            var cols = input[1];

            int[][] rubikMatrix = new int[rows][];
            GetMatrix(rows, cols, rubikMatrix);

            for (int i = 0; i < commandsNumber; i++)
            {
                var commandArgs = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var direction = commandArgs[1];
                var numberOfRotations = int.Parse(commandArgs[2]);

                var row = 0;
                var column = 0;

                switch (direction)
                {
                    case "up":
                        column = int.Parse(commandArgs[0]);
                        MoveUp(rubikMatrix, numberOfRotations, column);
                        break;
                    case "down":
                        column = int.Parse(commandArgs[0]);
                        MoveDown(rubikMatrix, numberOfRotations, column);
                        break;
                    case "right":
                        row = int.Parse(commandArgs[0]);
                        MoveRight(rubikMatrix, numberOfRotations, row);
                        break;
                    case "left":
                        row = int.Parse(commandArgs[0]);
                        MoveLeft(rubikMatrix, numberOfRotations, row);
                        break;
                }
            }

            RearrangeRubikMatrix(rubikMatrix);

            // PrintRubikCube(rubikMatrix);
        }

        private static void GetMatrix(int rows, int cols, int[][] rubikMatrix)
        {
            var number = 1;

            for (int row = 0; row < rows; row++)
            {
                rubikMatrix[row] = new int[cols];

                for (int col = 0; col < cols; col++)
                {
                    rubikMatrix[row][col] = number;
                    number++;
                }
            }
        }

        private static void RearrangeRubikMatrix(int[][] rubikMatrix)
        {
            var correctNumber = 1;

            for (int currentRow = 0; currentRow < rubikMatrix.Length; currentRow++)
            {
                for (int currentCol = 0; currentCol < rubikMatrix[0].Length; currentCol++)
                {
                    var currentNumber = rubikMatrix[currentRow][currentCol];

                    if (currentNumber != correctNumber)
                    {
                        for (int row = 0; row < rubikMatrix.Length; row++)
                        {
                            for (int col = 0; col < rubikMatrix[0].Length; col++)
                            {
                                if (rubikMatrix[row][col] == correctNumber)
                                {
                                    rubikMatrix[currentRow][currentCol] = rubikMatrix[row][col];
                                    rubikMatrix[row][col] = currentNumber;

                                    Console.WriteLine($"Swap ({currentRow}, {currentCol}) with ({row}, {col})");
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No swap required");
                    }

                    correctNumber++;
                }
            }
        }

        private static void MoveLeft(int[][] rubikMatrix, int numberOfRotations, int row)
        {
            for (int j = 0; j < numberOfRotations % rubikMatrix[0].Length; j++)
            {
                var leftNumber = rubikMatrix[row][0];

                for (int col = 0; col < rubikMatrix[0].Length - 1; col++)
                {
                    rubikMatrix[row][col] = rubikMatrix[row][col + 1];
                }
                rubikMatrix[row][rubikMatrix[0].Length - 1] = leftNumber;
            }
        }

        private static void MoveRight(int[][] rubikMatrix, int numberOfRotations, int row)
        {
            for (int j = 0; j < numberOfRotations % rubikMatrix[0].Length; j++)
            {
                var rightNumber = rubikMatrix[row][rubikMatrix[0].Length - 1];

                for (int col = rubikMatrix[0].Length - 1; col > 0; col--)
                {
                    rubikMatrix[row][col] = rubikMatrix[row][col - 1];
                }
                rubikMatrix[row][0] = rightNumber;
            }
        }

        private static void MoveDown(int[][] rubikMatrix, int numberOfRotations, int column)
        {
            for (int j = 0; j < numberOfRotations % rubikMatrix.Length; j++)
            {
                var lastNumber = rubikMatrix[rubikMatrix.Length - 1][column];

                for (int row = rubikMatrix.Length - 1; row > 0; row--)
                {
                    rubikMatrix[row][column] = rubikMatrix[row - 1][column];
                }
                rubikMatrix[0][column] = lastNumber;
            }
        }

        private static void MoveUp(int[][] rubikMatrix, int numberOfRotations, int column)
        {
            for (int j = 0; j < numberOfRotations % rubikMatrix.Length; j++)
            {
                var firstElement = rubikMatrix[0][column];

                for (int row = 0; row < rubikMatrix.Length - 1; row++)
                {
                    rubikMatrix[row][column] = rubikMatrix[row + 1][column];
                }

                rubikMatrix[rubikMatrix.Length - 1][column] = firstElement;
            }
        }

        private static void PrintRubikCube(int[][] rubikCube)
        {
            foreach (var row in rubikCube)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
