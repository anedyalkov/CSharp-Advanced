namespace _04.Even_Times
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var numbers = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                var count = 0;
                var number = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(number))
                {
                    numbers[number] = count;
                }
                numbers[number]++;
            }

            foreach (var kvp in numbers)
            {
                var number = kvp.Key;
                var count = kvp.Value;

                if (count % 2 == 0)
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}
