namespace _05._RubiksMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new int[matrixSize[0]][];
            var count = 1;

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[matrixSize[1]];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = count;
                    count++;
                }
            }

            var commandsNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsNum; i++)
            {
                var commandToken = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var rcIndex = int.Parse(commandToken[0]);
                var direction = commandToken[1];
                var moves = int.Parse(commandToken[2]);

                switch (direction)
                {
                    case "up":
                        MoveCol(matrix, rcIndex, moves);
                        break;

                    case "down":
                        MoveCol(matrix, rcIndex, matrix.Length - moves % matrix.Length);
                        break;

                    case "left":
                        MoveRow(matrix, rcIndex, moves);
                        break;

                    case "right":
                        MoveRow(matrix, rcIndex, matrix[0].Length - moves % matrix[0].Length);
                        break;
                }
            }

            var element = 1;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == element)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int rowindex = 0; rowindex < matrix.Length; rowindex++)
                        {
                            for (int colindex = 0; colindex < matrix[rowindex].Length; colindex++)
                            {
                                if (matrix[rowindex][colindex] == element)
                                {
                                    var currentElement = matrix[row][col];
                                    matrix[row][col] = element;
                                    matrix[rowindex][colindex] = currentElement;
                                    Console.WriteLine($"Swap ({row}, {col}) with ({rowindex}, {colindex})");
                                    break;
                                }
                            }
                        }
                    }

                    element++;
                }
            }

        }

        private static void MoveRow(int[][] matrix, int rcIndex, int moves)
        {
            var temp = new int[matrix[0].Length];

            for (int col = 0; col < matrix[0].Length; col++)
            {
                temp[col] = matrix[rcIndex][(col + moves) % matrix[0].Length];
            }

            matrix[rcIndex] = temp;

        }

        private static void MoveCol(int[][] matrix, int rcIndex, int moves)
        {
            var temp = new int[matrix.Length];

            for (int rowindex = 0; rowindex < matrix.Length; rowindex++)
            {
                temp[rowindex] = matrix[(rowindex + moves) % matrix.Length][rcIndex];
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row][rcIndex] = temp[row];
            }
        }
    }
}
