using System;
using System.IO;

namespace Reader
{
    class Read
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"Changing the names of {args[0]}");
        }

        void RecorreDirectorio(string path)
        {
            DirectoryInfo d = new DirectoryInfo(path);

            if (!d.Exists)
            {
                throw new Exception();
            }

            FileInfo[] files = d.GetFiles("*.mp3");

            foreach (FileInfo file in files)
            {
                //ProcessFile(file.FullName);
            }

            string[] subDirectorios = Directory.GetDirectories(path);
            foreach (string subdirectory in subDirectorios)
                RecorreDirectorio(subdirectory);
        }
    }
}