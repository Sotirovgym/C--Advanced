namespace _06._TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var commandsCount = int.Parse(Console.ReadLine());

            var queue = new Queue<string>();

            for (int i = 0; i < commandsCount; i++)
            {
                var args = Console.ReadLine();
                queue.Enqueue(args);
            }

            var isArrived = false;

            for (int start = 0; start < queue.Count; start++)
            {
                var fuel = 0;

                foreach (var item in queue)
                {
                    var fuelAmount = item.Trim()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray()[0];

                    var distance = item.Trim()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray()[1];

                    fuel += fuelAmount;
                    fuel -= distance;

                    if (fuel < 0)
                    {
                        isArrived = false;
                        break;
                    }
                    else
                    {
                        isArrived = true;
                    }
                }

                if (isArrived)
                {
                    Console.WriteLine(start);
                    return;
                }
                var helper = queue.Dequeue();
                queue.Enqueue(helper);
            }
        }
    }
}
