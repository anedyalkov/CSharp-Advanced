namespace _03.Crypto_Blockchain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var count = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();

            var numbers = new List<int>();

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine();
                sb.Append(input);
            }

            var line = sb.ToString();
            string pattern = @"({|\[).*?(\d{3,}).*?(}|\])";

            var regex = new Regex(pattern);

            var matches = regex.Matches(line);

            foreach (Match match in matches)
            {
                if ((match.Groups[1].ToString() == "{" && match.Groups[3].ToString() == "}") || (match.Groups[1].ToString() == "[" && match.Groups[3].ToString() == "]"))
                {
                    var fullMatch = match.Value;
                    string nums = match.Groups[2].Value;

                    for (int i = 0; i < nums.Length; i++)
                    {
                        string substring = nums.Substring(i, 3);
                        var number = int.Parse(substring);
                        var subtractedNumber = number - fullMatch.Length;
                        numbers.Add(subtractedNumber);
                        i += 2;
                    }
                }
            }

            char[] listOfchars = new char[numbers.Count];
            for (int i = 0; i < numbers.Count; i++)
            {
                var currentChar = (char)numbers[i];
                listOfchars[i] = currentChar;
            }

            var text = new string(listOfchars);
            Console.WriteLine(text);
        }
    }
}
