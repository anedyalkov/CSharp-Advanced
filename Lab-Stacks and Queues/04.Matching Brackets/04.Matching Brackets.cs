namespace _04.Matching_Brackets
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }

                if (input[i] == ')')
                {
                    var poppedIndex = stack.Pop();
                    var currentIndex = i;
                    
                    var length = currentIndex - poppedIndex;

                    var result = input.Substring(poppedIndex, length + 1);

                    Console.WriteLine(result);
                }
            }
        }
    }
}
