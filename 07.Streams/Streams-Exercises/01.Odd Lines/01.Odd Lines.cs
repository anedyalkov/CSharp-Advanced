﻿namespace _01.Odd_Lines
{
    using System;
    using System.IO;

    public class Program
    {
        public static void Main()
        {
            using (var reader = new StreamReader("../../../../Files/text.txt"))
            {
                int lineNum = 0;

                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    if (lineNum % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }

                    lineNum++;
                }
            }
        }
    }
}
