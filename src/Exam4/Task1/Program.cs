
    string solutionPath = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\..\\");
    string filePath = Path.Combine(solutionPath, "large.txt");

    long targetSizeInBytes = 5L * 1024 * 1024 * 1024;
    long currentSizeInBytes = 0;

    if (File.Exists(filePath))
    {
        Console.WriteLine("File already exists!");
        return;
    }

    Console.WriteLine("Creating a 5 GB file...");

    try
    {
        using (Stream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            Random random = new Random();

            while (currentSizeInBytes < targetSizeInBytes)
            {
                char randomChar = GetRandomChar(random);
                byte[] charBytes = BitConverter.GetBytes(randomChar);
                fs.Write(charBytes, 0, charBytes.Length);
                currentSizeInBytes += charBytes.Length;
            }
        }

        Console.WriteLine($"File creation completed. File size: {currentSizeInBytes / (1024.0 * 1024.0 * 1024.0):F2} GB");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }

    static char GetRandomChar(Random random)
    {
        return (char)random.Next('A', 'Z');
    }
