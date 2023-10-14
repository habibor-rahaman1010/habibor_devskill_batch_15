using System;

namespace WayTooLongWords
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                if (word.Length > 10)
                {
                    string abbreviatedWord = $"{word[0]}{word.Length - 2}{word[word.Length - 1]}";
                    Console.WriteLine(abbreviatedWord);
                }
                else
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}

