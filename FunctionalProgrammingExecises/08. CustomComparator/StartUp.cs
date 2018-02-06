namespace _08._CustomComparator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] tempNumber;
            var result = new List<int>();

            tempNumber = numbers
                .Where(n => n % 2 == 0)
                .OrderBy(n => n)
                .ToArray();

            result.AddRange(tempNumber);

            tempNumber = numbers
                .Where(n => n % 2 != 0)
                .OrderBy(n => n)
                .ToArray();

            result.AddRange(tempNumber);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
