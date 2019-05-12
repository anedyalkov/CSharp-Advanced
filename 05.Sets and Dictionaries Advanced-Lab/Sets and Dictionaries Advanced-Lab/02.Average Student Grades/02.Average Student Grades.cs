namespace _02.Average_Student_Grades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var count = int.Parse(Console.ReadLine());
            var studentsGrades = new Dictionary<string, List<double>>();

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
                var name = input[0];
                var grade = double.Parse(input[1]);

                if (!studentsGrades.ContainsKey(name))
                {
                    studentsGrades[name] = new List<double>();
                }

                studentsGrades[name].Add(grade);
            }

            foreach (var kvp in studentsGrades)
            {
                var student = kvp.Key;
                var grades = kvp.Value;
                var averageGrade = grades.Average();

                Console.Write($"{student} -> ");

                foreach (var grade in grades)
                {
                    Console.Write($"{grade:F2} ");
                }

                Console.Write($"(avg: {averageGrade:F2})");
                Console.WriteLine();
            }
        }
    }
}

