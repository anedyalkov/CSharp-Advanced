namespace _04.Cups_and_Bottles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var cups = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var bottles = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var bottlesStack = new Stack<int>(bottles);
            var cupsQueue = new Queue<int>(cups);
            var wastedWater = 0;

            while (true)
            {
                var currentBottle = bottlesStack.Peek();
                var currentcup = cupsQueue.Peek();

                var currentCupValue = currentcup - currentBottle;

                if (currentCupValue <= 0)
                {
                    cupsQueue.Dequeue();
                    bottlesStack.Pop();
                    wastedWater += Math.Abs(currentCupValue);
                }
                else
                {
                    currentBottle = bottlesStack.Pop();
                    while (currentCupValue > 0)
                    {
                        //if (bottlesStack.Count == 0)
                        //{
                        //    break;
                        //}    
                        currentBottle = bottlesStack.Pop();
                        currentCupValue = currentCupValue - currentBottle;
                        
                    }
                    wastedWater += Math.Abs(currentCupValue);
                    cupsQueue.Dequeue();
                }

                if (cupsQueue.Count == 0)
                {
                    break;
                }
                if (bottlesStack.Count == 0)
                {
                    break;
                }

            }
            if (cupsQueue.Count == 0)
            {
                Console.Write($"Bottles: ");
                foreach (var bottle in bottlesStack)
                {
                    Console.Write($"{bottle} ");
                }
                Console.WriteLine();
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            if (bottlesStack.Count == 0)
            {
                Console.Write($"Cups: ");
                foreach (var cup in cupsQueue)
                {
                    Console.Write($"{cup} ");
                }
                Console.WriteLine();
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
        }
    }
}
