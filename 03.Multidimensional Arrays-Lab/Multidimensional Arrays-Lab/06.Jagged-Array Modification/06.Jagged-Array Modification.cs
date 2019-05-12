namespace _06.Jagged_Array_Modification
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var jaggedArraySize = int.Parse(Console.ReadLine());

            List<List<int>> jaggedArray = GetJaggedArray(jaggedArraySize);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                jaggedArray = ModifyJaggedArray(jaggedArray,input);
            }
            PrintJaggedArray(jaggedArray);
        }

        public static List<List<int>> ModifyJaggedArray(List<List<int>> jaggedArray, string input)
        {
            var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            var command = tokens[0];
            var row = int.Parse(tokens[1]);
            var col = int.Parse(tokens[2]);
            var value = int.Parse(tokens[3]);

            if (command == "Add")
            {
                try
                {
                    jaggedArray[row][col] += value;
                }
                catch (Exception)
                {

                    Console.WriteLine($"Invalid coordinates");
                }
               
            }
            if (command == "Subtract")
            {
                try
                {
                    jaggedArray[row][col] -= value;
                }
                catch (Exception)
                {

                    Console.WriteLine($"Invalid coordinates");
                }
            }

            return jaggedArray;
        }

        public static void PrintJaggedArray(List<List<int>> jaggedArray)
        {
            for (int i = 0; i < jaggedArray.Count; i++)
            {
                for (int j = 0; j < jaggedArray[i].Count; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static List<List<int>> GetJaggedArray(int jaggedArraySize)
        {
            List<List<int>> jaggedArray = new List<List<int>>();

            for (int i = 0; i < jaggedArraySize; i++)
            {
                jaggedArray.Add(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            }

            return jaggedArray;
        }
    }
}
