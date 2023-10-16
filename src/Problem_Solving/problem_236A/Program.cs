using System;
using System.Collections.Generic;

namespace BoyOrGirl
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            HashSet<char> distinctChars = new HashSet<char>();

            foreach (char c in username)
            {
                distinctChars.Add(c);
            }

            if (distinctChars.Count % 2 == 0)
            {
                Console.WriteLine("CHAT WITH HER!");
            }
            else
            {
                Console.WriteLine("IGNORE HIM!");
            }
        }
    }
}
