namespace _02._BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var inputParams = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var stack = new Stack<int>();

            var numbersToPush = inputParams[0];
            var numbersToPop = inputParams[1];
            var numberToCheck = inputParams[2];

            for (int i = 0; i < numbersToPush; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < numbersToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(numberToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count > 0)
                {
                    Console.WriteLine(stack.Min());
                }
                else
                {
                    Console.WriteLine(stack.Count);
                }
            }
        }
    }
}
