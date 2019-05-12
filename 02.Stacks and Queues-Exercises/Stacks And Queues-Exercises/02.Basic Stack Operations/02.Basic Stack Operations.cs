namespace _02.Basic_Stack_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var pushElements = input[0];
            var popElements = input[1];
            var number = input[2];

            var numbers = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>(numbers);

            for (int i = 0; i < popElements; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("0");
                return;
            }
            bool containsNumber = stack.Contains(number);

            if (containsNumber)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
