using System;

namespace ChatRoom
{
    class Program
    {
        static bool CheckHello(string s)
        {
            string hello = "hello";
            int index = 0;

            foreach (char c in s)
            {
                if (c == hello[index])
                {
                    index++;
                    if (index == hello.Length)
                        return true;
                }
            }

            return false;
        }
        static void Main(string[] args)
        {
            string s = Console.ReadLine().Trim();
            Console.WriteLine(CheckHello(s) ? "YES" : "NO");
        }
    }
}