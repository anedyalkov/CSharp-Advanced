namespace _05.Count_Symbols
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var symbols = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                var currentSymbol = input[i];
                if (!symbols.ContainsKey(currentSymbol))
                {
                    symbols[currentSymbol] = 0;
                }
                symbols[currentSymbol]++;
            }

            foreach (var kvp in symbols)
            {
                var symbol = kvp.Key;
                var count = kvp.Value;

                Console.WriteLine($"{symbol}: {count} time/s");
            }
        }
    }
}
