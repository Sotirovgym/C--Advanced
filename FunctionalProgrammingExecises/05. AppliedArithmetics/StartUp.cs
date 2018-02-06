namespace _05._AppliedArithmetics
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var command = Console.ReadLine();

            Func<int, int> add = n => n += 1;
            Func<int, int> multiply = n => n * 2;
            Func<int, int> subtract = n => n -= 1;
            Action<int[]> print = n => Console.WriteLine(string.Join(" ", n));

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            numbers[i] = add(numbers[i]);
                        }
                        break;
                    case "multiply":
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            numbers[i] = multiply(numbers[i]);
                        }
                        break;
                    case "subtract":
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            numbers[i] = subtract(numbers[i]);
                        }
                        break;
                    case "print":
                        print(numbers);
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
