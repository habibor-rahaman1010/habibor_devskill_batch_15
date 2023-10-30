using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter the string: ");
        string input = Console.ReadLine();

        string result = ModifyString(input);

        Console.WriteLine(result);
    }

    static string ModifyString(string input)
    {
        string withoutSpecialChars = Regex.Replace(input, "[^a-zA-Z0-9_ ]", "");
        string[] words = withoutSpecialChars.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < words.Length; i++)
        {
            words[i] = CapitalizeFirstLetter(words[i].Replace("_", " "));
        }

        return string.Join(" ", words);
    }

    static string CapitalizeFirstLetter(string word)
    {
        if (string.IsNullOrEmpty(word))
        {
            return string.Empty;
        }

        return char.ToUpper(word[0]) + word.Substring(1).ToLower();
    }
}
