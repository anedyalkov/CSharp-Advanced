namespace _02.Simple_Calculator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var elements = input.Split(' ');

            var stack = new Stack<string>();

            for (int i = elements.Length-1; i >= 0; i--)
            {
                stack.Push(elements[i]);
            }

            while (stack.Count > 1)
            {
                var leftOperand = int.Parse(stack.Pop());
                var operation = stack.Pop();
                var rightOperand = int.Parse(stack.Pop());

                switch (operation)
                {
                    case "+":
                        stack.Push((leftOperand + rightOperand).ToString());
                        break;
                    case "-":
                        stack.Push((leftOperand - rightOperand).ToString());
                        break;
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
