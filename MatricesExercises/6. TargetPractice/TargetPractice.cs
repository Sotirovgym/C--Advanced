using System;
using System.Collections.Generic;
using System.Linq;

class TargetPractice
{
    static void Main()
    {
        var dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var snake = Console.ReadLine();
        var shotParameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var impactRow = shotParameters[0];
        var impactCol = shotParameters[1];
        var radius = shotParameters[2];

        var matrix = new char[dimensions[0]][];

        FillingTheMatrixWithSnakes(dimensions, snake, matrix);

        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                var isInside = (impactRow - row) * (impactRow - row) + (impactCol - col) * (impactCol - col) <= radius * radius;

                if (isInside)
                {
                    matrix[row][col] = ' ';
                }
            }
        }

        for (int col = 0; col < dimensions[1]; col++)
        {
            FallingSymbols(matrix, col);
        }


        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join("", row));
        }

    }

    private static void FallingSymbols(char[][] matrix, int col)
    {
        while (true)
        {
            var hasFallen = false;

            for (int row = 1; row < matrix.Length; row++)
            {
                var topChar = matrix[row - 1][col];
                var currentChar = matrix[row][col];

                if (currentChar == ' ' && topChar != ' ')
                {
                    matrix[row][col] = topChar;
                    matrix[row - 1][col] = ' ';
                    hasFallen = true;
                }
            }

            if (!hasFallen)
            {
                break;
            }
        }
        
    }

    private static void FillingTheMatrixWithSnakes(int[] dimensions, string snake, char[][] matrix)
    {
        var snakeIndex = 0;
        var climbLeftOrRight = 0;

        for (int row = matrix.Length - 1; row >= 0; row--)
        {
            matrix[row] = new char[dimensions[1]];

            if (climbLeftOrRight % 2 == 0)
            {
                for (int col = dimensions[1] - 1; col >= 0; col--)
                {
                    matrix[row][col] = snake[snakeIndex];

                    snakeIndex++;
                    if (snakeIndex == snake.Length)
                    {
                        snakeIndex = 0;
                    }
                }
            }
            else
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = snake[snakeIndex];

                    snakeIndex++;
                    if (snakeIndex == snake.Length)
                    {
                        snakeIndex = 0;
                    }
                }
            }

            climbLeftOrRight++;
        }
    }
}

