namespace _02._KnightsOfHonor
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> result = n => Console.WriteLine("Sir " + string.Join(Environment.NewLine + "Sir ", n));

            result(input);
        }
    }
}