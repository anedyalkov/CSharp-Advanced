namespace _03.Greedy_Times
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var bagCapacity = long.Parse(Console.ReadLine());
            var dict = new Dictionary<string, Dictionary<string, long>>();
            dict["Gold"] = new Dictionary<string, long>();
            dict["Gem"] = new Dictionary<string, long>();
            dict["Cash"] = new Dictionary<string, long>();

            //var goldSum = dict["Gold"].Sum(x => x.Value);
            //var gemSum = dict["Gem"].Sum(x => x.Value);
            //var cashSum = dict["Cash"].Sum(x => x.Value);
            long goldSum = 0;
            long gemSum = 0;
            long cashSum = 0;

            var line = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < line.Length - 1; i += 2)
            {
               
                var item = line[i];
                var quantity = int.Parse(line[i + 1]);
                var IsExceedingBagsCapacity = dict.Sum(x => x.Value.Values.Sum(w => w)) + quantity > bagCapacity;
                if (IsExceedingBagsCapacity)
                {
                    break;
                }

                if (item == "Gold")
                {
                    //dict["Gold"] = new Dictionary<string, long>();
                    if (!dict["Gold"].ContainsKey(item))
                    {
                        dict["Gold"][item] = 0;
                    }

                    dict["Gold"][item] += quantity;
                    goldSum += quantity;
                }
                else if (item.Length >= 4 && item.ToLower().EndsWith("gem"))
                {

                    gemSum += quantity;
                    if (goldSum < gemSum)
                    {
                        gemSum -= quantity;
                        continue;
                    }
                    else
                    {
                        //dict["Gem"] = new Dictionary<string, long>();
                        if (!dict["Gem"].ContainsKey(item))
                        {
                            dict["Gem"][item] = 0;
                        }
                    }
                    dict["Gem"][item] += quantity;

                }
                else if (item.Length == 3)
                {

                    cashSum += quantity;
                    if (gemSum < cashSum)
                    {
                        cashSum -= quantity;
                        continue;
                    }
                    else
                    {
                        //dict["Cash"] = new Dictionary<string, long>();
                        if (!dict["Cash"].ContainsKey(item))
                        {
                            dict["Cash"][item] = 0;
                        }
                    }
                    dict["Cash"][item] += quantity;

                }
            }

            var orderedDict = dict
                .OrderByDescending(x => x.Value.Sum(y => y.Value))
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in orderedDict)
            {
                var type = kvp.Key;
                var items = kvp.Value.OrderByDescending(x => x.Key).ThenBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                long totalAmount = items.Sum(x => x.Value);
                if (totalAmount == 0)
                {
                    continue;
                }
                Console.WriteLine($"<{type}> ${totalAmount}");

                foreach (var item in items)
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }
    }
}
