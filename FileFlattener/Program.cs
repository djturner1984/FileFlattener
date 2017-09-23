using System;

namespace FileFlattener
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Please use 'dotnet FileFlattener.dll [SourceFolderPath] [DestinationFolderPath]");
                Console.ReadKey();
                return;
            }
            string sourcePath = args[0];
            string destPath = args[1];
            Console.WriteLine($"This app will copy from {sourcePath} to {destPath}");
            Console.WriteLine("Please press any key to continue.");
            Console.ReadKey();
            var traverseService = new TraverseService();
            var fileService = new FileService();
            var files = traverseService.GetAllFilesFromFolder(sourcePath, true);
            var numberOfFiles = fileService.Copy(files, destPath);
            Console.WriteLine($"Successfully copied {numberOfFiles} files");
        }
    }
}
