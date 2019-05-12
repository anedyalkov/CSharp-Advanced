namespace _03.Product_Shop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            string input;
            var shops = new Dictionary<string, Dictionary<string, double>>();
            while ((input = Console.ReadLine()) != "Revision")
            {
                var tokens = input.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
                var shop = tokens[0];
                var product = tokens[1];
                var price = double.Parse(tokens[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops[shop] = new Dictionary<string, double>();
                }

                if (!shops[shop].ContainsKey(product))
                {
                    shops[shop][product] = price;
                }

            }

            var oderedShops = shops.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var kvp in oderedShops)
            {
                var shop = kvp.Key;
                var productPrice = kvp.Value;
                Console.WriteLine($"{shop}->");
                foreach (var pair in productPrice)
                {
                    var product = pair.Key;
                    var price = pair.Value;
                    Console.WriteLine($"Product: {product}, Price: {price}");
                }
            }
        }
    }
}
