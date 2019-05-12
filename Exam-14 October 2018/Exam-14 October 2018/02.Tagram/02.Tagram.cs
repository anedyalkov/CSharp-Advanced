namespace _02.Tagram
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {            
            var users = new Dictionary<string, Dictionary<string, int>>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                var tokens = input.Split(" ->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (tokens.Length > 2)
                {
                    var user = tokens[0];
                    var tag = tokens[1];
                    var likes = int.Parse(tokens[2]);

                    if (!users.ContainsKey(user))
                    {
                        users[user] = new Dictionary<string, int>();
                    }

                    if (!users[user].ContainsKey(tag))
                    {
                        users[user][tag] = 0;
                    }

                    users[user][tag] += likes;
                }
                else
                {
                    var name = tokens[1];
                    if (users.ContainsKey(name))
                    {
                        users.Remove(name);
                    }
                }
            }

            var orderedUsers = users
                .OrderByDescending(x => x.Value.Sum(y => y.Value))
                .ThenBy(x => x.Value.Count)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in orderedUsers)
            {
                var user = item.Key;
                var tagAndLikes = item.Value;

                Console.WriteLine($"{user}");

                foreach (var kvp in tagAndLikes)
                {
                    var tag = kvp.Key;
                    var likes = kvp.Value;
                    Console.WriteLine($"- { tag}: { likes}");
                }
            }

        }
    }
}
