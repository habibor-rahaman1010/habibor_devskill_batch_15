using System;

namespace SoldierAndBananas
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int k = int.Parse(input[0]);
            int n = int.Parse(input[1]);
            int w = int.Parse(input[2]);

            int totalCost = 0;
            for (int i = 1; i <= w; i++)
            {
                totalCost += i * k;
            }

            Console.WriteLine(Math.Max(0, totalCost - n));
        }
    }
}

