using System;

namespace Task1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the input: ");
            string[] input = Console.ReadLine().Split();
            int numerator = int.Parse(input[0]);
            int denominator = int.Parse(input[1]);
            int decimalPlaces = int.Parse(input[2]);
            string result = CalculateFraction(numerator, denominator, decimalPlaces);

            Console.WriteLine($"{result}");
        }

        static string CalculateFraction(int numerator, int denominator, int length)
        {
            string result = "";
            int remainder = numerator;

            result += (numerator / denominator).ToString();
            result += ".";

            while (length > 0)
            {
                remainder = remainder % denominator;
                remainder *= 10;
                int quotient = remainder / denominator;
                result += quotient.ToString();
                length--;

                if (remainder == 0)
                {
                    break;
                }
            }
            return result;
        }
    }
}
