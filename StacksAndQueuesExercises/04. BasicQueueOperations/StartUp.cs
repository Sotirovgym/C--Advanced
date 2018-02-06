namespace _04._BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var queue = new Queue<int>();

            var inputParams = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var countToAdd = inputParams[0];
            var countToRemove = inputParams[1];
            var numberToCheck = inputParams[2];

            for (int i = 0; i < countToAdd; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < countToRemove; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(numberToCheck))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count != 0)
            {
                Console.WriteLine(queue.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
