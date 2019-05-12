namespace _07.The_V_Logger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var vloggers = new Dictionary<string, Dictionary<string, SortedSet<string>>>();
            string input;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                var tokens = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (tokens.Length > 3)
                {
                    var logger = tokens[0];
                    if (!vloggers.ContainsKey(logger))
                    {
                        vloggers[logger] = new Dictionary<string, SortedSet<string>>();
                        vloggers[logger]["following"] = new SortedSet<string>();
                        vloggers[logger]["followers"] = new SortedSet<string>();
                    }

                }
                else
                {
                    var follower = tokens[0];
                    var logger = tokens[2];
                    bool isSamePerson = follower == logger;

                    if (!vloggers.ContainsKey(follower) || !vloggers.ContainsKey(logger))
                    {
                        continue;
                    }
                    if (isSamePerson)
                    {
                        continue;
                    }

                    vloggers[logger]["followers"].Add(follower);
                    vloggers[follower]["following"].Add(logger);
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            var ordered = vloggers
                .OrderByDescending(x => x.Value["followers"].Count)
                .ThenBy(x => x.Value["following"].Count)
                .ToDictionary(x => x.Key, x => x.Value);

            var counter = 1;
            foreach (var kvp in ordered)
            {
                var logger = kvp.Key;
                var dict = kvp.Value;


                Console.WriteLine($"{counter}. {kvp.Key} : {kvp.Value["followers"].Count} followers, {kvp.Value["following"].Count} following");

                if (counter == 1)
                {
                    foreach (var item in kvp.Value["followers"])
                    {
                        Console.WriteLine($"*  {item}");
                    }
                }

                counter++;
            }
        }
    }
}
