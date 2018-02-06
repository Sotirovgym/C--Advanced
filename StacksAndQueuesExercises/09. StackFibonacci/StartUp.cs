namespace _09._StackFibonacci
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var fibNumbers = new Stack<BigInteger>();
            fibNumbers.Push(0);
            fibNumbers.Push(1);

            if (n <= 2)
            {
                Console.WriteLine(1);
                Environment.Exit(0);
            }

            for (int i = 0; i < n - 1; i++)
            {
                var previousNumber = fibNumbers.Peek();
                var nextNumber = fibNumbers.Pop() + fibNumbers.Pop();

                fibNumbers.Push(previousNumber);
                fibNumbers.Push(nextNumber);
            }

            Console.WriteLine(fibNumbers.Peek());
        }
    }
}
