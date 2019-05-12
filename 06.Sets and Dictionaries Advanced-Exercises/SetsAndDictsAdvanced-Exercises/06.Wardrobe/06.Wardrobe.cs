namespace _06.Wardrobe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries).ToArray();

                var color = line[0].Trim();
                var clothes = line[1].Split(",".ToCharArray(),StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }
                for (int j = 0; j < clothes.Length; j++)
                {
                    var currentVest = clothes[j].Trim();
                    if (!wardrobe[color].ContainsKey(currentVest))
                    {
                        wardrobe[color][currentVest] = 0;
                    }
                    wardrobe[color][currentVest]++;
                }
            }

            var input = Console.ReadLine().Split().ToArray();

            var wantedColor = input[0];
            var wantedVest = input[1];

            foreach (var colorClothes in wardrobe)
            {
                var color = colorClothes.Key;
                var clothes = colorClothes.Value;

                Console.WriteLine($"{color} clothes:");

                foreach (var vestCount in clothes)
                {
                    var vest = vestCount.Key;
                    var count = vestCount.Value;

                    if (wantedColor == color)
                    {
                        if (wantedVest == vest)
                        {
                            Console.WriteLine($"* {vest} - {count} (found!)");
                        }
                        else
                        {
                            Console.WriteLine($"* {vest} - {count}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"* {vest} - {count}");
                    }
                    
                }           
            }
        }
    }
}
