namespace _08.Pascal_Triangle
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var size = int.Parse(Console.ReadLine());

            List<List<long>> triangle = GetPascalTriangle(size);

            PrintTriangle(size, triangle);
        }

        public  static void PrintTriangle(int size, List<List<long>> triangle)
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(string.Join(" ", triangle[i]));
            }
        }

        public static List<List<long>> GetPascalTriangle(int size)
        {
            List<List<long>> triangle = new List<List<long>>();

            for (int i = 0; i < size; i++)
            {
                triangle.Add(new List<long>());
            }
            triangle[0].Add(1);

            for (int i = 1; i < size; i++)
            {
                triangle[i].Add(1);
                for (int j = 1; j < triangle[i - 1].Count; j++)
                {
                    triangle[i].Add(triangle[i - 1][j - 1] + triangle[i - 1][j]);
                }
                triangle[i].Add(1);
            }

            return triangle;
        }
    }
}
