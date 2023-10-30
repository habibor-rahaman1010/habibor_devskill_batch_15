Console.WriteLine("Enter the number of rows: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter the number of columns: ");
int columns = Convert.ToInt32(Console.ReadLine());

char[,] matrix = new char[rows, columns];

Console.WriteLine("Enter the elements of the matrix row by row: ");
for (int i = 0; i < rows; i++)
{
    string rowInput = Console.ReadLine();
    for (int j = 0; j < columns; j++)
    {
        matrix[i, j] = rowInput[j];
    }
}

int maxCount = 1;
for (int i = 0; i < rows; i++)
{
    int count = 1;
    for (int j = 1; j < columns; j++)
    {
        if (matrix[i, j] == matrix[i, j - 1])
        {
            count++;
            maxCount = Math.Max(maxCount, count);
        }
        else
        {
            count = 1;
        }
    }
}

Console.WriteLine($"The adjacent characters is: {maxCount}");
