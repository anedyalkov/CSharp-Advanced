namespace _05.Calculate_Sequence_with_Queue
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var currentNumber = long.Parse(Console.ReadLine());

            var sequenceOfNumbers = new Queue<long>();
            var secondSequenceOfNumbers = new Queue<long>();

            secondSequenceOfNumbers.Enqueue(currentNumber);

            while (secondSequenceOfNumbers.Count < 50)
            {
                secondSequenceOfNumbers.Enqueue(currentNumber + 1);
                sequenceOfNumbers.Enqueue(currentNumber + 1);

                if (secondSequenceOfNumbers.Count < 50)
                {
                    secondSequenceOfNumbers.Enqueue(2 * currentNumber + 1);
                    sequenceOfNumbers.Enqueue(2 * currentNumber + 1);
                }

                if (secondSequenceOfNumbers.Count < 50)
                {
                    secondSequenceOfNumbers.Enqueue(currentNumber + 2);
                    sequenceOfNumbers.Enqueue(currentNumber + 2);
                    currentNumber = sequenceOfNumbers.Dequeue();
                }
            }
            Console.WriteLine(string.Join(" ", secondSequenceOfNumbers));
        }
    }
}
