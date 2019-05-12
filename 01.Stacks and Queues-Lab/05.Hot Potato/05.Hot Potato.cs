namespace _05.Hot_Potato
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var tossLimit = int.Parse(Console.ReadLine());

            var players = input.Split(' ');

            var queue = new Queue<string>(players);

            while (queue.Count != 1)
            {
                for (int i = 1; i < tossLimit; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                Console.WriteLine($"Removed {queue.Dequeue()}");
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
