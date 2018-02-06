namespace _03._Maximum_Element
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();
            var maxElement = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                var inputParams = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var command = inputParams[0];

                switch (command)
                {
                    case 1:
                        var element = inputParams[1];

                        if (maxElement < element)
                        {
                            maxElement = element;
                        }

                        stack.Push(element);
                        break;

                    case 2:
                        var removedElement = stack.Pop();
                        if (maxElement == removedElement)
                        {
                            if (stack.Count != 0)
                            {
                                maxElement = stack.Max();
                                break;
                            }
                            maxElement = 0;
                        }
                        break;

                    case 3:
                        Console.WriteLine(maxElement);
                        break;
                }
            }
        }
    }
}
