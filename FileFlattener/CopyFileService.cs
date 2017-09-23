using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileFlattener
{
    internal class FileService
    {
        public int Copy(List<String> filePaths, string destinationFolderPath)
        {
            int filesCopied = 0;
            if (!Directory.Exists(destinationFolderPath))
            {
                Directory.CreateDirectory(destinationFolderPath);
            }

            foreach (var filePath in filePaths)
            {
                if (CopyFile(filePath, destinationFolderPath))
                {
                    filesCopied++;
                }
            }

            return filesCopied;
        }

        private bool CopyFile(string sourcePath, string destPath)
        {
            try
            {
                var filename = Path.GetFileName(sourcePath);
                File.Copy(sourcePath, Path.Combine(destPath, filename), true);
                Console.WriteLine($"Successfully copied from {sourcePath} to {destPath}");
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to copy from {sourcePath} to {destPath}");
                Console.WriteLine($"Exception: {ex.Message}");
                return false;
            }
            
        }
    }
}
