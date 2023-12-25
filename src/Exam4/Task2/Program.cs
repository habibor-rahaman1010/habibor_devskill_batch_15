    
    string solutionPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
    string filePath = @"..\\..\\..\\..\\large.txt";
    string originalFilePath = Path.Combine(solutionPath, filePath);

    if (!File.Exists(originalFilePath))
    {
        Console.WriteLine("The original file does not exist. Please generate it first.");
        return;
    }

    int chunkSizeInBytes = 100 * 1024 * 1024;
    int folderCounter = 1;
    int fileCounter = 1;

    try
    {
        using (FileStream originalFileStream = new FileStream(originalFilePath, FileMode.Open, FileAccess.Read))
        {
            while (originalFileStream.Position < originalFileStream.Length)
            {
                if (fileCounter > 10)
                {
                    folderCounter++;
                    fileCounter = 1;
                }

                string folderName = $"Folder{folderCounter}";
                string folderPath = Path.Combine(solutionPath, folderName);

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string newFilePath = Path.Combine(folderPath, $"SplitFile{fileCounter}.txt");

                using (FileStream splitFileStream = new FileStream(newFilePath, FileMode.Create))
                {
                    byte[] buffer = new byte[1024];

                    long bytesRead = 0;
                    int read;

                    while (bytesRead < chunkSizeInBytes && (read = originalFileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        splitFileStream.Write(buffer, 0, read);
                        bytesRead += read;
                    }
                }

                fileCounter++;
            }
        }

        Console.WriteLine("File splitting completed.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
  