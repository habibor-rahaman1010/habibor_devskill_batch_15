Console.WriteLine("Enter the size of the pattern: ");
int n = Convert.ToInt32(Console.ReadLine());

if (n%2 != 0 && n > 0)
{
    for (int i = 1; i <= n; i++)
    {
        if (i <= (n + 1) / 2)
        {
            Console.Write(new string(' ', n - i));
            Console.WriteLine(new string('*', 2 * i - 1));
        }
        else
        {
            Console.Write(new string(' ', i - 1));
            Console.WriteLine(new string('*', 2 * (n - i) + 1));
        }
    }
}
Console.WriteLine("\n");