namespace _07._LegoBlocks
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var rowSize = int.Parse(Console.ReadLine());

            var firstArray = new int[rowSize][];
            var secondArray = new int[rowSize][];

            var totalCells = 0;

            for (int i = 0; i < rowSize * 2; i++)
            {
                if (i < rowSize)
                {
                    firstArray[i] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    totalCells += firstArray[i].Length;
                }
                else
                {
                    secondArray[i - rowSize] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Reverse().ToArray();
                    totalCells += secondArray[i - rowSize].Length;
                }
            }

            var isFit = true;

            for (int i = 1; i < rowSize; i++)
            {
                if (firstArray[i - 1].Length + secondArray[i - 1].Length != firstArray[i].Length + secondArray[i].Length)
                {
                    isFit = false;
                }
            }

            if (isFit)
            {
                for (int i = 0; i < rowSize; i++)
                {
                    Console.WriteLine("[" + string.Join(", ", firstArray[i]) + ", " + string.Join(", ", secondArray[i]) + "]");
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {totalCells}");
            }
        }
    }
}
