using System;

namespace Task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter first large number:");
            string num1 = Console.ReadLine();

            Console.WriteLine("Enter second large number:");
            string num2 = Console.ReadLine();

            Console.WriteLine(AddLargeNumbers(num1, num2));
        }
        public static string AddLargeNumbers(string num1, string num2)
        {
            int maxLength = Math.Max(num1.Length, num2.Length);
            num1 = num1.PadLeft(maxLength, '0');
            num2 = num2.PadLeft(maxLength, '0');

            char[] result = new char[maxLength + 1];
            int carry = 0;

            for (int i = maxLength - 1; i >= 0; i--)
            {
                int digit1 = num1[i] - '0';
                int digit2 = num2[i] - '0';

                int sum = digit1 + digit2 + carry;
                carry = sum / 10;
                result[i + 1] = (char)((sum % 10) + '0');
            }

            result[0] = (char)(carry + '0');
            string sumString = new string(result);
            sumString = sumString.TrimStart('0');
            return sumString;
        }
    }
}