using System;

namespace _061.Traffic_Light
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var carsCanPass = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();
            var counter = 0;
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                if (input != "green")
                {
                    queue.Enqueue(input);
                }
                else
                {
                    
                    if (queue.Count >= carsCanPass)
                    {
                        for (int i = 0; i < carsCanPass; i++)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed! ");
                            counter++;
                        }
                    }
                    else
                    {
                        var moves = Math.Min(queue.Count, carsCanPass);
                        for (int i = 0; i < moves; i++)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            counter++;
                        }
                    }             
                }
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
