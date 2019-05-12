namespace _08.Stack_Fibonacci
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var counter = int.Parse(Console.ReadLine());
            var stack = new Stack<long>();
            stack.Push(0);
            stack.Push(1);

            for (int i = 0; i < counter -1; i++)
            {
                var firstNumber = stack.Pop();
                var secondNumber = stack.Peek();
                stack.Push(firstNumber);
                var currentNumber = firstNumber + secondNumber;
                stack.Push(currentNumber);
            }
            Console.WriteLine(stack.Peek());
        }
    }
}
