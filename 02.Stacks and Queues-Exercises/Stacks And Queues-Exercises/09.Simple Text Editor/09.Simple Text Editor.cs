namespace _09.Simple_Text_Editor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var counter = int.Parse(Console.ReadLine());
            string text = string.Empty;
            var stack = new Stack<string>();

            for (int i = 0; i < counter; i++)
            {
                var input = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

                var command = input[0];
                if (command == "1")
                {
                    string currentText = input[1];
                    stack.Push(text);
                    text += currentText;
                }
                else if (command == "2")
                {
                    var count = int.Parse(input[1]);
                    stack.Push(text);
                    text = text.Substring(0, text.Length - count);
                }
                else if (command == "3")
                {
                    int index = int.Parse(input[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (command == "4")
                {
                    text = stack.Pop();
                }
            }
        }
    }
}



