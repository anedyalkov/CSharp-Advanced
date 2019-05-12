namespace _07._SoftUni_Party
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var guestList = new SortedSet<string>();

            string input = Console.ReadLine();
            while (input != "PARTY")
            {
                guestList.Add(input);
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "END")
            {
                guestList.Remove(input);
                input = Console.ReadLine();
            }
            Console.WriteLine(guestList.Count);
            foreach (var guest in guestList)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
