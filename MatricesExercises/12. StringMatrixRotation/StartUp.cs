namespace _12._StringMatrixRotation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        private static char[,] matrix;

        static void Main()
        {
            var rotateDegrees = Console.ReadLine();

            var regex = new Regex(@"[0-9]{1,5}").Match(rotateDegrees);

            var degrees = int.Parse(regex.Value) / 90;

            var input = Console.ReadLine();

            var words = new List<string>();

            while (input != "END")
            {
                words.Add(input);
                
                input = Console.ReadLine();
            }

            var rowsCount = words.Count;
            var colsCount = words.OrderByDescending(w => w.Length).FirstOrDefault().Length;
            var currentWordLength = 0;

            switch (degrees % 4)
            {
                case 1:
                    matrix = new char[colsCount, rowsCount];
                    for (int row = 0; row < matrix.GetLength(1); row++)
                    {
                        currentWordLength = words[words.Count - 1 - row].Length - 1;

                        for (int col = 0; col < matrix.GetLength(0); col++)
                        {
                            if (col <= currentWordLength)
                            {
                                matrix[col, row] = words[words.Count - 1 - row][col];
                            }
                            else
                            {
                                matrix[col, row] = ' ';
                            }
                        }
                    }
                    break;
                case 2:
                    matrix = new char[rowsCount, colsCount];
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        currentWordLength = words[words.Count - 1 - row].Length - 1;

                        var index = 0;
                        for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                        {
                            if (index <= currentWordLength)
                            {
                                matrix[row, col] = words[words.Count - 1 - row][index];
                                index++;
                            }
                            else
                            {
                                matrix[row, col] = ' ';
                            }
                        }
                    }
                    break;
                case 3:
                    matrix = new char[colsCount, rowsCount];
                    for (int row = 0; row < matrix.GetLength(1); row++)
                    {
                        currentWordLength = words[row].Length - 1;
                        var counter = 0;
                        for (int col = matrix.GetLength(0) - 1; col >= 0; col--)
                        {
                            if (counter <= currentWordLength)
                            {
                                matrix[col, row] = words[row][counter];
                                counter++;
                            }
                            else
                            {
                                matrix[col, row] = ' ';
                            }
                        }
                    }
                    break;
                case 0:
                    matrix = new char[rowsCount, colsCount];
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        currentWordLength = words[row].Length;
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (col < currentWordLength)
                            {
                                matrix[row, col] = words[row][col];
                            }
                            else
                            {
                                matrix[row, col] = ' ';
                            }
                        }
                    }
                    break;
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
