namespace _01.Count_Same_Values_in_Array
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            var dict = new Dictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!dict.ContainsKey(number))
                {
                    dict[number] = 0;
                }

                dict[number]++;
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
