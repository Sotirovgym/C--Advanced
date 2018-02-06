namespace _09._ListOfPredicates
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            if (n < 0)
            {
                return;
            }

            var devisible = Console.ReadLine().Split(' ').Select(int.Parse).Reverse().ToArray();
            var result = new int[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = i + 1;
            }

            for (int i = 0; i < devisible.Length; i++)
            {
                result = result.Where(s => s % devisible[i] == 0).ToArray();
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
