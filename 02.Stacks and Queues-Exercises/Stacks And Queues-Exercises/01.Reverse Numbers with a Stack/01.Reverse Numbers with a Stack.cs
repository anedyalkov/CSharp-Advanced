namespace _01.Reverse_Numbers_with_a_Stack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>(numbers);

            Console.WriteLine(string.Join(" ", stack));
        }
    }
}
