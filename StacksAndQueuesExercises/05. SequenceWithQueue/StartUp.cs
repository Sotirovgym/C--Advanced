﻿namespace _05._SequenceWithQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var queue = new Queue<long>();

            var n = long.Parse(Console.ReadLine());

            var s = n;

            queue.Enqueue(s);

            for (int i = 0, skipCount = 0;i < 49; i++)
            {
                switch (i % 3)
                {
                    case 0:
                        s = queue.ToArray().Skip(skipCount).Take(1).ToArray()[0];
                        queue.Enqueue(s + 1);
                        skipCount++;
                        break;
                    case 1:
                        queue.Enqueue((2 * s + 1));
                        break;
                    case 2:
                        queue.Enqueue(s + 2);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", queue));
        }
    }
}
