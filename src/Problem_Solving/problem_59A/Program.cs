using System;

namespace WordCasing
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            int upperCaseCount = 0;
            int lowerCaseCount = 0;

            foreach (char c in s)
            {
                if (Char.IsUpper(c))
                {
                    upperCaseCount++;
                }
                else
                {
                    lowerCaseCount++;
                }
            }

            if (upperCaseCount > lowerCaseCount)
            {
                Console.WriteLine(s.ToUpper());
            }
            else
            {
                Console.WriteLine(s.ToLower());
            }
        }
    }
}
