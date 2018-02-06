namespace _04._MaximalSum
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var sizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var matrix = new int[sizes[0], sizes[1]];

            var rowIndex = 0;
            var colIndex = 0;

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = input[cols];
                }
            }

            var maxSquareSum = 0;

            for (int rows = 0; rows < matrix.GetLength(0) - 2; rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1) - 2; cols++)
                {
                    var currentSquareSum = matrix[rows, cols] + matrix[rows, cols + 1] + matrix[rows, cols + 2] +
                                           matrix[rows + 1, cols] + matrix[rows + 1, cols + 1] + matrix[rows + 1, cols + 2] +
                                           matrix[rows + 2, cols] + matrix[rows + 2, cols + 1] + matrix[rows + 2, cols + 2];
                    if (maxSquareSum < currentSquareSum)
                    {
                        maxSquareSum = currentSquareSum;
                        rowIndex = rows;
                        colIndex = cols;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSquareSum}");
            Console.WriteLine($"{matrix[rowIndex, colIndex]} {matrix[rowIndex, colIndex + 1]} {matrix[rowIndex, colIndex + 2]}");
            Console.WriteLine($"{matrix[rowIndex + 1, colIndex]} {matrix[rowIndex + 1, colIndex + 1]} {matrix[rowIndex + 1, colIndex + 2]}");
            Console.WriteLine($"{matrix[rowIndex + 2, colIndex]} {matrix[rowIndex + 2, colIndex + 1]} {matrix[rowIndex + 2, colIndex + 2]}");
        }
    }
}
