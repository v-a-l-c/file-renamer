using System;
using System.IO;
using System.Text;

namespace Reader
{
    class Read
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"Changing the names of {args[0]}...");
            try
            {
                Console.WriteLine($"{GetFilesNumber(args[0])} files found.");
            }
            catch
            {
                Console.WriteLine("Unable to find path.");
            }
            try
            {
                RecorreDirectorio(args[0]);
                Console.WriteLine("Listooo");
            }
            catch
            {
                Console.WriteLine($"File already exists");
            }
        }
        public static int GetFilesNumber(string path)
        {
            int total = 0;
            DirectoryInfo d = new DirectoryInfo(path);

            if (!d.Exists)
            {
                throw new Exception();
            }

            FileInfo[] files = d.GetFiles();

            foreach (FileInfo file in files)
                total++;

            string[] subDirectorios = Directory.GetDirectories(path);
            foreach (string subdirectory in subDirectorios)
                total += GetFilesNumber(subdirectory);

            return total;
        }
        static void RecorreDirectorio(string path)
        {
            int nameOfFile = 97;
            DirectoryInfo d = new DirectoryInfo(path);

            if (!d.Exists)
            {
                throw new Exception();
            }

            FileInfo[] files = d.GetFiles("*.jpg");

            int level = 0;
            int amountOfFiles = 0;
            foreach (FileInfo file in files)
            {
                if (amountOfFiles < 26)
                {
                    amountOfFiles++;
                    ProcessFile(file, level, nameOfFile);
                    nameOfFile++;
                }
                else
                {
                    amountOfFiles = 0;
                    level++;
                    nameOfFile = 97;
                    ProcessFile(file, level, nameOfFile);
                    nameOfFile++;
                }
            }

            string[] subDirectorios = Directory.GetDirectories(path);
            foreach (string subdirectory in subDirectorios)
                RecorreDirectorio(subdirectory);
        }

        static void ProcessFile(FileInfo file, int level, int nameOfFile)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= level; i++)
            {
                sb.Append("z");
            }
            sb.Append((char)nameOfFile);
            sb.Append(".jpg");
            Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(file.FullName, sb.ToString());
        }
    }
}