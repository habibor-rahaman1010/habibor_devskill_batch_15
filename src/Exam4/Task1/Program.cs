DirectoryInfo currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
string newPath = Path.Combine(currentDirectory.Parent.Parent.Parent.Parent.FullName, "Data");

if (!Directory.Exists(newPath))
{
    Directory.CreateDirectory(newPath);
}

FileInfo file = new FileInfo(Path.Combine(newPath, "RandomTextFile.txt"));

if (!file.Exists)
{
    Console.WriteLine("Creating a 5 GB file...");

    try
    {
        using (FileStream fs = new FileStream(file.FullName, FileMode.CreateNew))
        {
            long fileSizeInBytes = 0;
            long targetSizeInBytes = 5L * 1024 * 1024 * 1024;
            byte[] buffer = new byte[1024 * 1024];

            while (fileSizeInBytes < targetSizeInBytes)
            {
                int bytesToWrite = (int)Math.Min(targetSizeInBytes - fileSizeInBytes, buffer.Length);

                for (int i = 0; i < bytesToWrite; i++)
                {
                    buffer[i] = (byte)GetRandomChar();
                }

                fs.Write(buffer, 0, bytesToWrite);
                fileSizeInBytes += bytesToWrite;
            }
        }

        Console.WriteLine("File creation completed.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}
else
{
    Console.WriteLine("File already exists");
}

static int GetRandomChar()
{
    Random random = new Random(DateTime.Now.Millisecond);
    return random.Next('A', 'Z');
}