namespace _03.Periodic_Table
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {

            var count = int.Parse(Console.ReadLine());

            var set = new SortedSet<string>();

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split().ToArray();

                for (int j = 0; j < input.Length; j++)
                {
                    set.Add(input[j]);
                }
            }

            foreach (var item in set)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
