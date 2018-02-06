namespace StacksAndQueuesExercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var reversedNumbers = new Stack<int>();

            foreach (var number in numbers)
            {
                reversedNumbers.Push(number);
            }

            Console.WriteLine(string.Join(" ", reversedNumbers));
        }
    }
}
