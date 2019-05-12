namespace _05.Record_Unique_Names
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var count = int.Parse(Console.ReadLine());
            var names = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                var name = Console.ReadLine();
                names.Add(name);
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
