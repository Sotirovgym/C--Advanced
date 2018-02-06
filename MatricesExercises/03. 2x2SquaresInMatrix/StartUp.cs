namespace _03._2x2SquaresInMatrix
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var sizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var matrix = new string[sizes[0], sizes[1]];
            var squareCount = 0;

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                var input = Console.ReadLine().Split(' ');

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = input[cols];
                }
            }

            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1) - 1; cols++)
                {
                    if (matrix[rows, cols] == matrix[rows, cols + 1] && 
                        matrix[rows, cols] == matrix[rows + 1, cols + 1] && 
                        matrix[rows, cols] == matrix[rows + 1, cols])
                    {
                        squareCount++;
                    }
                }
            }

            Console.WriteLine(squareCount);
        }
    }
}
