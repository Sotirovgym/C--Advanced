namespace _06._ReverseAndExclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).Reverse().ToList();
            var numberToDivide = int.Parse(Console.ReadLine());

            Predicate<int> isDevisible = n => n % numberToDivide == 0;
            Action<List<int>> print = n => Console.WriteLine(string.Join(" ", n));

            for (int i = 0; i < numbers.Count; i++)
            {
                if (isDevisible(numbers[i]))
                {
                    numbers.RemoveAt(i);
                    i--;
                }
            }

            print(numbers);
        }
    }
}
