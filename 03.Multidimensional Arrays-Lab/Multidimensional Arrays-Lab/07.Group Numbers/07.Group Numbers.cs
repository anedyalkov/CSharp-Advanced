namespace _07.Group_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<List<int>> remainders = GetRemainders(numbers);
            PrintNumbers(remainders);
        }

        public static void PrintNumbers(List<List<int>> remainders)
        {
            for (int i = 0; i < remainders.Count; i++)
            {
                Console.WriteLine(string.Join(" ", remainders[i]));
            }
        }

        public  static List<List<int>> GetRemainders(int[] numbers)
        {
            List<List<int>> remainders = new List<List<int>>();

            for (int i = 0; i < 3; i++)
            {
                remainders.Add(new List<int>());
            }

            foreach (var number in numbers)
            {
                var remainder = Math.Abs(number % 3);
                remainders[remainder].Add(number);
            }

            return remainders;
        }
    }
}
