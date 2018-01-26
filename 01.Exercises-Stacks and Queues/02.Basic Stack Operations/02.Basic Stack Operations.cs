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

            var numbers = Console.ReadLine()
                 .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            var pushingElements = input[0];
            var numberOfElementsToPop = input[1];
            var searchingElement = input[2];

            var stack = new Stack<int>();

            for (int i = 0; i < pushingElements; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < numberOfElementsToPop; i++)
            {
                stack.Pop();
            }

            var searchingElementExists = stack.Contains(searchingElement);

            if (searchingElementExists)
            {
                Console.WriteLine("true");
                return;
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
