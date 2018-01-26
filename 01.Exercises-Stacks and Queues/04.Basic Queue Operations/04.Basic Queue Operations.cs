namespace _04.Basic_Queue_Operations
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

            var queue = new Queue<int>();

            for (int i = 0; i < pushingElements; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < numberOfElementsToPop; i++)
            {
                queue.Dequeue();
            }

            var searchingElementExists = queue.Contains(searchingElement);

            if (searchingElementExists)
            {
                Console.WriteLine("true");
                return;
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
