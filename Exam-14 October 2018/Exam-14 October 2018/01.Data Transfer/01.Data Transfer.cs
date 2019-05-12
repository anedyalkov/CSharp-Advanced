namespace _01.Data_Transfer
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            string pattern = @"s:([^;]+);r:([^;]+);m--(""[A-Za-z\s]+"")";
            var regex = new Regex(pattern);
            var output = new StringBuilder();
 

            var n = int.Parse(Console.ReadLine().Trim());
            var sum = 0;
            for (int line = 0; line < n; line++)
            {
                var inputLine = Console.ReadLine();
               
                if (regex.IsMatch(inputLine))
                {
                    var match = regex.Match(inputLine);
                    var message = match.Groups[3].Value;

                    var sender = match.Groups[1].Value;
                    var senderName = string.Empty;
                    string pattern2 = @"[A-Za-z ]+";
                    var regex2 = new Regex(pattern2);
                    var matches = regex2.Matches(sender);

                    foreach (Match item in matches)
                    {
                        senderName += item.Value;
                    }
                    for (int i = 0; i < sender.Length; i++)
                    {
                        if (char.IsDigit(sender[i]))
                        {
                            sum += int.Parse((sender[i].ToString()));
                        }
                    }
                 
                    var receiver = match.Groups[2].Value;
                    var receiverName = string.Empty;
                    var recmatches = regex2.Matches(receiver);

                    foreach (Match item in recmatches)
                    {
                        receiverName += item.Value;
                    }
                    for (int i = 0; i < receiver.Length; i++)
                    {
                        if (char.IsDigit(receiver[i]))
                        {
                            sum += int.Parse((receiver[i].ToString()));
                        }
                    }

                    Console.WriteLine($"{senderName} says {message} to {receiverName}");
                  
                }
            }
            Console.WriteLine($"Total data transferred: {sum}MB");
        }
    }
}
