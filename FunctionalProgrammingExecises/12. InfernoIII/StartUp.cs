namespace _12._InfernoIII
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> result = numbers;
            var reverseFilter = new Stack<int>();
            var input = string.Empty;
            var counter = 0;

            while ((input = Console.ReadLine()) != "Forge")
            {
                var commandParams = input.Split(';');
                var command = commandParams[0];
                var filterType = commandParams[1];
                var filterParameter = int.Parse(commandParams[2]);

                if (command == "Exclude")
                {
                    switch (filterType)
                    {
                        case "Sum Left":
                            counter = SumLeft(numbers, reverseFilter, filterParameter, counter);
                            break;
                        case "Sum Right":
                            counter = SumRight(numbers, reverseFilter, filterParameter, counter);
                            break;
                        case "Sum Left Right":
                            counter = SumLeftRight(numbers, reverseFilter, filterParameter, counter);
                            break;
                    }
                }
                else if (command == "Reverse")
                {
                    for (int i = 0; i < counter; i++)
                    {
                        reverseFilter.Pop();
                    }
                }
            }

            numbers.RemoveAll(n => reverseFilter.Contains(numbers.IndexOf(n)));

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static int SumLeftRight(List<int> numbers, Stack<int> reverseFilter, int filterParameter, int counter)
        {
            counter = 0;
            //Check Sum of index 0
            if (0 + numbers[0] + numbers[1] == filterParameter)
            {
                reverseFilter.Push(0);
                counter++;
            }

            for (int i = 1; i < numbers.Count - 1; i++)
            {
                var leftRightSum = numbers[i - 1] + numbers[i] + numbers[i + 1];
                if (leftRightSum == filterParameter)
                {
                    reverseFilter.Push(i);
                    counter++;
                }
            }

            //Check Sum of last index
            var lastIndex = numbers.Count - 1;
            if (numbers[lastIndex - 1] + numbers[lastIndex] + 0 == filterParameter)
            {
                reverseFilter.Push(lastIndex);
                counter++;
            }

            return counter;
        }

        private static int SumRight(List<int> numbers, Stack<int> reverseFilter, int filterParameter, int counter)
        {
            counter = 0;

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] + numbers[i + 1] == filterParameter)
                {
                    reverseFilter.Push(i);
                    counter++;
                }
            }
            if (numbers[numbers.Count - 1] == filterParameter)
            {
                reverseFilter.Push(numbers.Count - 1);
                counter++;
            }

            return counter;
        }

        private static int SumLeft(List<int> numbers, Stack<int> reverseFilter, int filterParameter, int counter)
        {
            counter = 0;

            if (numbers[0] == filterParameter)
            {
                reverseFilter.Push(0);
                counter++;
            }
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i - 1] + numbers[i] == filterParameter)
                {
                    reverseFilter.Push(i);
                    counter++;
                }
            }

            return counter;
        }
    }
}