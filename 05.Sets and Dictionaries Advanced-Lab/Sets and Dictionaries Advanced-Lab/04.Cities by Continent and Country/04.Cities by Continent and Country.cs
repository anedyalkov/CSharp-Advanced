namespace _04.Cities_by_Continent_and_Country
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                var continent = input[0];
                var country = input[1];
                var city = input[2];

                if (!continents.ContainsKey(continent))
                {
                    continents[continent] = new Dictionary<string, List<string>>();
                }

                if (!continents[continent].ContainsKey(country))
                {
                    continents[continent][country] = new List<string>();
                }

                continents[continent][country].Add(city);
            }

            foreach (var kvp in continents)
            {
                var continent = kvp.Key;
                var countryCities = kvp.Value;

                Console.WriteLine($"{continent}:");

                foreach (var countryTowns in countryCities)
                {
                    var country = countryTowns.Key;
                    var towns = countryTowns.Value;

                    Console.WriteLine($"{country} -> {string.Join(", ", towns)}");
                }
            }
        }
    }
}
