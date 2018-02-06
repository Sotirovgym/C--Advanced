namespace _01._ActionPoint
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> result = n => Console.WriteLine(string.Join(Environment.NewLine, n));

            result(input);
        }
    }
}
