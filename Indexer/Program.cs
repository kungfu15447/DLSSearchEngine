using System;
using System.Collections.Generic;
using System.IO;
using Indexer.Models;

namespace Indexer
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Crawl(new DirectoryInfo("./Data"));
            var documents = new List<Document>();
            var terms = new List<Term>();
            var occurences = new List<Occurence>();

            foreach (var file in files)
            {
                Console.WriteLine($"Filename: {file.FullName}");
            }
        }

        private static IEnumerable<FileInfo> Crawl(DirectoryInfo dir)
        {
            foreach (FileInfo file in dir.EnumerateFiles()) 
            {
                yield return file;
            }

            foreach (DirectoryInfo subDir in dir.EnumerateDirectories())
            {
                foreach (FileInfo subFile in Crawl(subDir))
                {
                    yield return subFile;
                }
            }
        }
    }
}
