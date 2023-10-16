using System;

namespace Tram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int minCapacity = 0;
            int currentCapacity = 0;

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                int a = int.Parse(input[0]);
                int b = int.Parse(input[1]);

                currentCapacity = currentCapacity - a + b;

                if (currentCapacity > minCapacity)
                {
                    minCapacity = currentCapacity;
                }
            }

            Console.WriteLine(minCapacity);
        }
    }
}
