using System;

namespace BitPlusPlus
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int x = 0;

            for (int i = 0; i < n; i++)
            {
                string statement = Console.ReadLine();
                if (statement == "++")
                {
                    x++;
                }
                else if (statement == "--")
                {
                    x--;
                }
            }
            Console.WriteLine(x);
        }
    }
}

