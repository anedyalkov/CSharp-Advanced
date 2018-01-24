namespace _06._2.Traffic_Light
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var numberOfCars = int.Parse(Console.ReadLine());

            var command = Console.ReadLine();
            var carsQueue = new Queue<string>();
            var carsThatPassedTotal = 0;
            while (command != "end")
            {
                if (command != "green")
                {
                    carsQueue.Enqueue(command);
                }
                else
                {
                    var carsThatCanPassed = Math.Min(carsQueue.Count, numberOfCars);

                    for (int i = 0; i < carsThatCanPassed; i++)
                    {

                        Console.WriteLine($"{ carsQueue.Dequeue()} passed!");
                        carsThatPassedTotal++;
                    }
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"{carsThatPassedTotal} cars passed the crossroads.");
        }
    }
}
