
    string solutionPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
    string task2Path = Path.Combine(solutionPath, "Task2");
    string mergedFilePath = Path.Combine(task2Path, "MergedFile.txt");

    if (!Directory.Exists(task2Path))
    {
        Console.WriteLine("Task2 directory not found. Please run Task2 project first.");
        return;
    }

    string[] splitFiles = Directory.GetFiles(task2Path, "SplitFile*.txt")
                                    .OrderByDescending(file => int.Parse(Path.GetFileNameWithoutExtension(file).Substring("SplitFile".Length)))
                                    .ToArray();

    if (splitFiles.Length == 0)
    {
        Console.WriteLine("No split files found. Please run Task2 project to generate split files.");
        return;
    }

    try
    {
        using (FileStream mergedFileStream = new FileStream(mergedFilePath, FileMode.Create, FileAccess.Write))
        {
            foreach (string splitFile in splitFiles)
            {
                using (FileStream splitFileStream = new FileStream(splitFile, FileMode.Open, FileAccess.Read))
                {
                    splitFileStream.CopyTo(mergedFileStream);
                }
            }
        }

        Console.WriteLine($"File merging completed. Merged file saved at: {mergedFilePath}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }

