using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileFlattener
{
    internal class TraverseService
    {
        private static List<string> _filePaths = new List<String>();
        public List<String> GetAllFilesFromFolder(string pathToFolder, bool traverseSubfolders)
        {
            _filePaths.Clear();
            WalkDirectoryTree(new DirectoryInfo(pathToFolder), traverseSubfolders);
            return _filePaths;
        }

        private void WalkDirectoryTree(System.IO.DirectoryInfo root, bool traverseSubfolders)
        {
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            // First, process all the files directly under this folder
            try
            {
                files = root.GetFiles("*.*");
            }
            // This is thrown if even one of the files requires permissions greater
            // than the application provides.
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Unauthorized access to directory: {root.FullName}");
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine($"Directory not found: {root.FullName}");

            }

            if (files != null)
            {
                foreach (System.IO.FileInfo fi in files)
                {
                    _filePaths.Add(fi.FullName);
                }

                if (!traverseSubfolders)
                    return;


                subDirs = root.GetDirectories();

                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    WalkDirectoryTree(dirInfo, traverseSubfolders);
                }
            }
        }
    }
}
