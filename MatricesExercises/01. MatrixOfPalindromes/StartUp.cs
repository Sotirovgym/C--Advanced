namespace MatrixOfPalindromes
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var rowsAndColumns = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            string[,] matrix = new string[rowsAndColumns[0], rowsAndColumns[1]];

            var alphabetical = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = $"{alphabetical[rows]}{alphabetical[rows + cols]}{alphabetical[rows]}";
                }
            }

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.Write(matrix[rows, cols] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
