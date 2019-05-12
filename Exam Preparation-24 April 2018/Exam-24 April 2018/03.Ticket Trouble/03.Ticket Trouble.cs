namespace _03.Ticket_Trouble
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var tokens = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

            var countryCode = tokens[0];
            var cityCode = tokens[1];

            //string pattern = @"\[[^\[\]]*{[^{}]+}[^\[\]]+\]|{[^{}]*\[[^\[\]]+\][^{}]+}";
            //string pattern2 = @"\[[^\[\]]*{BHS PN}[^\[\]]*{[A-Z][0-9]{1,2}}[^\[\]]*\]|{[^{}]*\[BHS PN\][^{}]*\[[A-Z][0-9]{1,2}\][^{}]*}";
            string pattern = @"\[[^\[\]]*{(?<destination>[A-Z]{3} [A-Z]{2})}[^\[\]]*{(?<seatnumber>[A-Z][0-9]{1,2})}[^\[\]]*\]|{[^{}]*\[(?<destination>[A-Z]{3} [A-Z]{2})\][^{}]*\[(?<seatnumber>[A-Z][0-9]{1,2})\][^{}]*}";

            var input = Console.ReadLine();
            var matches = Regex.Matches(input, pattern);

            List<string> seatNumbers = new List<string>();
            List<int> rows = new List<int>();

            foreach (Match match in matches)
            {
                var currentMatch = match.Value;
                var destination = match.Groups["destination"].Value.Split().ToArray();
                var seatNumber = match.Groups["seatnumber"].Value;

                if (destination[0] != countryCode || destination[1] != cityCode)
                {
                    continue;
                }

                seatNumbers.Add(seatNumber);
            }

            if (seatNumbers.Count > 2)
            {
                var dict = new Dictionary<int, int>();
                for (int i = 0; i < seatNumbers.Count; i++)
                {
                    var row = int.Parse(new string(seatNumbers[i].Skip(1).ToArray()));
                    rows.Add(row);
                    if (!dict.ContainsKey(row))
                    {
                        dict[row] = 0;
                    }

                    dict[row] += 1;
                }

                //for (int i = 0; i < rows.Count; i++)
                //{
                //    if (!dict.ContainsKey(rows[i]))
                //    {
                //        dict[rows[i]] = 0;
                //    }

                //    dict[rows[i]]+=1;
                //}
                var finalRow = 0;
                foreach (var pair in dict)
                {
                    if (pair.Value == 2)
                    {
                        finalRow = pair.Key;
                    }
                }

                var finalSeats = new List<string>();

                for (int i = 0; i < seatNumbers.Count; i++)
                {
                    if (seatNumbers[i].Contains(finalRow.ToString()))
                    {
                        finalSeats.Add(seatNumbers[i]);
                    }
                }

                Console.WriteLine($"You are traveling to {countryCode} {cityCode} on seats {finalSeats[0]} and {finalSeats[1]}.");
            }
            else
            {
                Console.WriteLine($"You are traveling to {countryCode} {cityCode} on seats {seatNumbers[0]} and {seatNumbers[1]}.");
            }
        }
    }
}

