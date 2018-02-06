namespace _07._PredicateForNames
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var length = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> checkLength = n => n.Length <= length;

            for (int i = 0; i < names.Length; i++)
            {
                if (checkLength(names[i]))
                {
                    Console.WriteLine(names[i]);
                }
            }
        }
    }
}
