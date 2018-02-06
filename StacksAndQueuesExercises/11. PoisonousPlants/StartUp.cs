namespace _11._PoisonousPlants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var plants = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var stack = new Stack<int>();
            var days = new int[n];

            for (int i = 0; i < plants.Length; i++)
            {
                var maxDays = 0;

                while (stack.Count > 0 && plants[stack.Peek()] >= plants[i])
                {
                    maxDays = Math.Max(maxDays, days[stack.Pop()]);
                }

                if (stack.Count > 0)
                {
                    days[i] = maxDays + 1;
                }
                stack.Push(i);
            }
            Console.WriteLine(days.Max());
        }
    }
}
