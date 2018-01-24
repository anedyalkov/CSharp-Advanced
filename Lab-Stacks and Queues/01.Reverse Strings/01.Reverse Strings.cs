namespace _01.Reverse_Strings
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var stack = new Stack<char>(input.ToCharArray());

            //foreach (var charachter in input)
            //{
            //    stack.Push(charachter);
            //}

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();

            //Console.ReadKey();
        }
    }
}
