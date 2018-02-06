namespace _02._DiagonalDifference
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var squareSize = int.Parse(Console.ReadLine());

            var matrix = new int[squareSize, squareSize];

            var primaryDiagonal = 0;
            var secondaryDiagonal = 0;

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                var numbers = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var count = 0;
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = numbers[cols];

                    if (rows == cols)
                    {
                        primaryDiagonal += matrix[rows, cols];
                    }

                    if (count == matrix.GetLength(0) - 1 - rows)
                    {
                        secondaryDiagonal += matrix[rows, matrix.GetLength(1) - 1 - rows];
                    }

                    count++;
                }
            }
            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}
