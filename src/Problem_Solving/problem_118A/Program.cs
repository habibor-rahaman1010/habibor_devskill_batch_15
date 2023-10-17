using System;

namespace StringTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            input = input.ToLower();

            string result = "";

            foreach (char c in input)
            {
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' || c == 'y')
                {
                    continue;
                }
                else
                {
                    result += "." + c;
                }
            }
            Console.WriteLine(result);
        }
    }
}
