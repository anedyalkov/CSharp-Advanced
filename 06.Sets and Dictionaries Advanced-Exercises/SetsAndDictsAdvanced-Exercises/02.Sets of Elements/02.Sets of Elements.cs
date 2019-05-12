namespace _02.Sets_of_Elements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().ToArray();
            var firstSetLength = int.Parse(input[0]);
            var secondSetLength = int.Parse(input[1]);

            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();


            for (int i = 0; i < firstSetLength; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < secondSetLength; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            foreach (var number in firstSet)
            {
                foreach (var num in secondSet)
                {
                    if (number == num)
                    {
                        Console.Write(number + " ");
                        break;
                    }
                }
            }
        }
    }
}
