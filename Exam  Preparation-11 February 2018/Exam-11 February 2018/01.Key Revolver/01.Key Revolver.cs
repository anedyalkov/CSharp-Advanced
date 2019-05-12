namespace _01.Key_Revolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var bulletPrice = int.Parse(Console.ReadLine());
            var gunBarrelSize = int.Parse(Console.ReadLine());
            var bullets = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var locks = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var intelligenceValue = int.Parse(Console.ReadLine());

            var bulletsStack = new Stack<int>(bullets);
            var locksQueue = new Queue<int>(locks);

            var reloadingCounter = 0;
            while (bulletsStack.Count > 0)
            {
                if (locksQueue.Count > 0)
                {

                    var currentBullet = bulletsStack.Pop();
                    reloadingCounter++;
                    intelligenceValue -= bulletPrice;

                    if (currentBullet <= locksQueue.Peek())
                    {
                        Console.WriteLine("Bang!");
                        locksQueue.Dequeue();
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                    }
                    if (reloadingCounter == gunBarrelSize)
                    {
                        if (bulletsStack.Count > 0)
                        {
                            Console.WriteLine("Reloading!");
                            reloadingCounter = 0;
                        }

                    }
                }
                else
                {
                    Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${intelligenceValue}");
                    return;
                }               
            }

            if (bulletsStack.Count == 0 && locksQueue.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
                return;
            }
            if (bulletsStack.Count == 0 && locksQueue.Count == 0)
            {
                Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${intelligenceValue}");
                return;
            }
        }
    }
}
