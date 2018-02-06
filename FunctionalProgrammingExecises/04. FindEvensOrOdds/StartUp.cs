namespace _04._FindEvensOrOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var rangeOrNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var startNumber = rangeOrNumbers[0];
            var endNumber = rangeOrNumbers[1];
            var filteredNumber = new List<int>();
            var command = Console.ReadLine();

            Predicate<int> isOdd = n => n % 2 != 0;

            if (command == "odd")
            {
                for (int i = startNumber; i <= endNumber; i++)
                {
                    if (isOdd(i))
                    {
                        filteredNumber.Add(i);
                    }
                }
            }
            else if (command == "even")
            {
                for (int i = startNumber; i <= endNumber; i++)
                {
                    if (!isOdd(i))
                    {
                        filteredNumber.Add(i);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", filteredNumber));
        }
    }
}
