namespace _04.Hit_List
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var personsInfo = new Dictionary<string, Dictionary<string, string>>();
            var targetIndex = int.Parse(Console.ReadLine());

            string input;
            while ((input = Console.ReadLine())!= "end transmissions")
            {
                var tokens = input.Split("=;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
                var name = tokens[0];
                for (int i = 1; i < tokens.Length; i++)
                {

                    var currentKeyValue = tokens[i].Split(':', StringSplitOptions.RemoveEmptyEntries).ToArray();
                    var currentKey = currentKeyValue[0];
                    var currentValue = currentKeyValue[1];

                    if (!personsInfo.ContainsKey(name))
                    {
                        personsInfo[name] = new Dictionary<string, string>();
                    }
                    if (!personsInfo[name].ContainsKey(currentKey))
                    {
                        personsInfo[name][currentKey] = currentValue;
                    }
                    else
                    {
                        personsInfo[name][currentKey] = currentValue;
                    }
                }
            }

            var secondInput = Console.ReadLine();
            var element = secondInput.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            var targetName = element[1];

            var target = personsInfo
                .Where(x => x.Key == targetName)
                     .ToDictionary(x => x.Key,
                                   x => x.Value.OrderBy(y => y.Key)
                                   .ToDictionary(y => y.Key, y => y.Value));

            int infoIndex = 0;
            foreach (var item in target)
            {
                var name = item.Key;
                var keyValues = item.Value;
                Console.WriteLine($"Info on {name}:");
                
                foreach (var kvp in keyValues)
                {
                    var info = kvp.Key;
                    var value = kvp.Value;

                    infoIndex += info.Length + value.Length;

                    Console.WriteLine($"---{info}: {value}");
                }
            }
            Console.WriteLine($"Info index: {infoIndex}");
            if (infoIndex >= targetIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetIndex-infoIndex} more info.");
            }
        }
    }
}
