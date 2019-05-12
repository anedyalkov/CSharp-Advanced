namespace _01.Unique_Usernames
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var count = int.Parse(Console.ReadLine());

            var set = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine();

                set.Add(input);
            }

            foreach (var name in set)
            {
                Console.WriteLine(name);
            }
        }
    }
}
