namespace _06.Parking_Lot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            string input;
            var parkingLot = new HashSet<string>();
            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
                var command = tokens[0];
                var carNumber = tokens[1];

                if (command == "IN")
                {
                    parkingLot.Add(carNumber);
                }
                if (command == "OUT")
                {
                    parkingLot.Remove(carNumber);
                }
            }

            if (parkingLot.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var carNumber in parkingLot)
                {
                    Console.WriteLine(carNumber);
                }
            }
        }
    }
}
