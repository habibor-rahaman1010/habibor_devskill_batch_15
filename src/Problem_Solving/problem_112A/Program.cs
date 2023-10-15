using System;

namespace PetyaAndStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = Console.ReadLine().ToLower();
            string str2 = Console.ReadLine().ToLower();

            int result = string.Compare(str1, str2);

            if (result < 0)
            {
                Console.WriteLine("-1");
            }
            else if (result > 0)
            {
                Console.WriteLine("1");
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
