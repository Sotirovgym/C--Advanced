namespace _03._CustomMinFunction
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Func<int[], int> result = n => n.Min();

            Console.WriteLine(result(numbers));
        }
    }
}
