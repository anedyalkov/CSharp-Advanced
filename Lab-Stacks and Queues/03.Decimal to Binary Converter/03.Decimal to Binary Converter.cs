namespace _03.Decimal_to_Binary_Converter
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();


            if (input == 0)
            {
                Console.WriteLine(0);
                return;
            }

            while (input > 0)
            {
                var remainder = input % 2;
                stack.Push(remainder);
                input /= 2;
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();
        }
    }
}
