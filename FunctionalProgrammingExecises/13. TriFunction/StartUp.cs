namespace _13._TriFunction
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var names = Console.ReadLine().Split(' ');

            foreach (var name in names)
            {
                var sumOfChars = 0;

                for (int i = 0; i < name.Length; i++)
                {
                    sumOfChars += name[i];
                }

                if (sumOfChars >= n)
                {
                    Console.WriteLine(name);
                    break;
                }
            }
        }
    }
}
