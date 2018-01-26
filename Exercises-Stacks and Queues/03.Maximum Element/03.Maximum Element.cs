namespace _03.Maximum_Element
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numberOfQueries = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();
            var maxStack = new Stack<int>();

            maxStack.Push(int.MinValue);

            for (int i = 0; i < numberOfQueries; i++)
            {
                var command = Console.ReadLine()
                    .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                
                if (command[0] == 1)
                {
                    var element = command[1];
                    stack.Push(element);

                    if (element >= maxStack.Peek())
                    {
                        maxStack.Push(element);
                    }
                }
                else if (command[0] == 2)
                {
                    var poppedElement = stack.Pop();
                    if (maxStack.Peek() == poppedElement)
                    {
                        maxStack.Pop();
                    }
                }
                else if (command[0] == 3)
                {
                    Console.WriteLine(maxStack.Peek());
                }
            }
        }
    }
}
