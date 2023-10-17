using System;

namespace Elephant
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int steps = (int)Math.Ceiling((double)x / 5);

            Console.WriteLine(steps);
        }
    }
}
