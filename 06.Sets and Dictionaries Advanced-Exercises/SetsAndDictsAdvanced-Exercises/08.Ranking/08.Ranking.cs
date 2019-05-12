namespace _08.Ranking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var contests = new Dictionary<string, string>();
            var users = new Dictionary<string, Dictionary<string, int>>();
            string input;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                var tokens = input.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

                var contest = tokens[0];
                var password = tokens[1];

                contests.Add(contest, password);
            }
            string secondInput;
            while ((secondInput = Console.ReadLine()) != "end of submissions")
            {
                var tokens = secondInput.Split("=>".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
                var contest = tokens[0];
                var password = tokens[1];
                var user = tokens[2];
                var points = int.Parse(tokens[3]);

                bool isValidContest = contests.Any(x => x.Key == contest);
                bool isValidPassword = contests.Any(x => x.Key == contest && x.Value == password);

                if (isValidContest && isValidPassword)
                {
                    if (!users.ContainsKey(user))
                    {
                        users[user] = new Dictionary<string, int>();
                    }
                    if (!users[user].ContainsKey(contest))
                    {
                        users[user][contest] = 0;
                    }
                    if (users[user][contest] < points)
                    {
                        users[user][contest] = points;
                    }
                }
            }

            var first = users
                .OrderByDescending(x => x.Value.Sum(y => y.Value))
                .FirstOrDefault();

            Console.WriteLine($"Best candidate is {first.Key} with total {first.Value.Sum(x => x.Value)} points.");

            Console.WriteLine("Ranking:");

            var ordered = users
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in ordered)
            {
                var user = kvp.Key;
                var cont = kvp.Value;
                Console.WriteLine($"{user}");

                foreach (var item in cont.OrderByDescending(x => x.Value))
                {
                    var contest = item.Key;
                    var points = item.Value;
                    Console.WriteLine($"#  {contest} -> {points}");
                }
            }
        }
    }
}
