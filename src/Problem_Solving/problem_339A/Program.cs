using System;

namespace HelpfulMaths
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            int[] numbers = s.Split('+').Select(int.Parse).ToArray();
            Array.Sort(numbers);
            string result = string.Join("+", numbers);
            Console.WriteLine(result);
        }
    }
}
