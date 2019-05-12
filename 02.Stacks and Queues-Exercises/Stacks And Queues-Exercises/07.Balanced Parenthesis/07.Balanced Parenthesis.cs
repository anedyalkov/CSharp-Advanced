using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Balanced_Parenthesis
{
    public class Program
    {
        public static void Main()
        {
            var parentheses = Console.ReadLine().ToCharArray();
            if (parentheses.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            var stack = new Stack<char>();
            bool isBalanced = true;
            var dict = new Dictionary<char, char>();
            foreach (var parenthes in parentheses)
            {
                if (parenthes == '{' || parenthes == '(' || parenthes == '[')
                {
                    if (!dict.ContainsKey(parenthes))
                    {
                        if (parenthes == '{')
                        {
                            dict[parenthes] = '}';
                        }
                        if (parenthes == '(')
                        {
                            dict[parenthes] = ')';
                        }
                        if (parenthes == '[')
                        {
                            dict[parenthes] = ']';
                        }
                    }
                }
                else
                {
                    stack.Push(parenthes);
                }
            }

            var array = stack.ToArray();
            var list = array.ToList();
            list = list.Distinct().ToList();
            var count = 0;
            foreach (var value in dict.Values)
            {
                if (value == list[count])
                {
                    count++;
                    continue;
                }
                else
                {
                    isBalanced = false;
                    break;
                }
            }
            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
