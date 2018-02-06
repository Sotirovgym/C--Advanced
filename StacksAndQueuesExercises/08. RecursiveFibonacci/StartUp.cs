namespace _08._RecursiveFibonacci
{
    using System;

    public class StartUp
    {
        private static long[] fibNumbers;

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            fibNumbers = new long[n];
            var result = Fibonaci(n);

            Console.WriteLine(result);
        }

        private static long Fibonaci(int n)
        {
            if (n <= 2)
            {
                return 1;
            }

            if (fibNumbers[n - 1] != 0)
            {
                return fibNumbers[n - 1];
            }

            return fibNumbers[n - 1] = Fibonaci(n - 1) + Fibonaci(n - 2);
        }
    }
}
