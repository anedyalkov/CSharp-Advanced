namespace _06.Truck_Tour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var circles = int.Parse(Console.ReadLine());

            var petrolPumps = new Queue<int[]>();
            for (int i = 0; i < circles; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                petrolPumps.Enqueue(input);
            }

            int index = 0;

            while (true)
            {
                var totalFuel = 0;
                foreach (var petrolPump in petrolPumps)
                {
                    var fuel = petrolPump[0];
                    var distance = petrolPump[1];
                    totalFuel += fuel - distance;
                    if (totalFuel < 0)
                    {
                        index++;
                        var petrolPumpToRemove = petrolPumps.Dequeue();
                        petrolPumps.Enqueue(petrolPumpToRemove);
                        break;
                    }
                }

                if (totalFuel >= 0)
                {
                    break;
                }
            }
            Console.WriteLine(index);
        }
    }
}
