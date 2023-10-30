using System;
using System.Text.RegularExpressions;

Console.WriteLine("Please enter the string: ");
string input = Console.ReadLine();

string result = ModifyString(input);
Console.WriteLine(result);


static string ModifyString(string input)
{
    string result = Regex.Replace(input, "[^a-zA-Z0-9_ ]", "");

    result = result.Replace('_', ' ');
    

    result = Regex.Replace(result, @"\s+", " ");

    return result.Trim();
}
