using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Adjust the path accordingly
        string projectFolderPath = Directory.GetCurrentDirectory();
        string dataFolderPath = Path.Combine(projectFolderPath, "Data");
        string originalFilePath = Path.Combine(dataFolderPath, "RandomTextFile.txt");

        // Check if the original file exists
        if (!File.Exists(originalFilePath))
        {
            Console.WriteLine("The original file does not exist. Please generate it first.");
            return;
        }

        // Create a directory to store split files and folders
        string splitFilesPath = Path.Combine(projectFolderPath, "SplitFiles");
        if (!Directory.Exists(splitFilesPath))
        {
            Directory.CreateDirectory(splitFilesPath);
        }

        using (FileStream originalFileStream = new FileStream(originalFilePath, FileMode.Open, FileAccess.Read))
        {
            int folderCounter = 1;
            int fileCounter = 1;
            long chunkSizeInBytes = 100 * 1024 * 1024; // 100 MB

            while (originalFileStream.Position < originalFileStream.Length)
            {
                // Create a new folder if the maximum number of files is reached
                if (fileCounter > 10)
                {
                    folderCounter++;
                    fileCounter = 1;
                }

                string folderName = $"Folder{folderCounter}";
                string folderPath = Path.Combine(splitFilesPath, folderName);

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string newFilePath = Path.Combine(folderPath, $"SplitFile{fileCounter}.txt");

                using (FileStream splitFileStream = new FileStream(newFilePath, FileMode.Create))
                {
                    byte[] buffer = new byte[1024]; // 1 KB buffer

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
}
