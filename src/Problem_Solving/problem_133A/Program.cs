using System;

namespace HQ
{
    class Program
    {
        static string CheckHQ9p(string program)
        {
            foreach (char c in program)
            {
                if (c == 'H' || c == 'Q' || c == '9')
                {
                    return "YES";
                }
            }
            return "NO";
        }
        static void Main(string[] args)
        {
            string p = Console.ReadLine().Trim();
            Console.WriteLine(CheckHQ9p(p));
        }
    }
}
