using System;
using System.Collections.Generic;
using System.IO;

namespace Indexer
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Crawl(new DirectoryInfo(""));
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
