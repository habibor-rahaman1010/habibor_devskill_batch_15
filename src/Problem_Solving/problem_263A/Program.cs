using System;

namespace BeautifulMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[5, 5];
            int row = -1, col = -1;

            for (int i = 0; i < 5; i++)
            {
                string[] input = Console.ReadLine().Split();
                for (int j = 0; j < 5; j++)
                {
                    matrix[i, j] = int.Parse(input[j]);
                    if (matrix[i, j] == 1)
                    {
                        row = i;
                        col = j;
                    }
                }
            }
            int rowMoves = Math.Abs(row - 2);
            int colMoves = Math.Abs(col - 2);
            int totalMoves = rowMoves + colMoves;
            Console.WriteLine(totalMoves);
        }
    }
}
