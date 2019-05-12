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

            var enqueueElements = input[0];
            var dequeueElements = input[1];
            var number = input[2];

            var numbers = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var queue = new Queue<int>(numbers);

            for (int i = 0; i < dequeueElements; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("0");
                return;
            }
            bool containsNumber = queue.Contains(number);

            if (containsNumber)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
