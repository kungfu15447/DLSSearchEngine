using System;
using System.Collections.Generic;
using System.IO;
using Indexer.Context;
using Indexer.Models;

namespace Indexer
{
    class Program
    {
        private static string DATA_FOLDER_NAME = "Data";
        private static string DATA_FOLDER_PATH = $"./{DATA_FOLDER_NAME}";
        static void Main(string[] args)
        {
            var files = Crawl(new DirectoryInfo(DATA_FOLDER_PATH));
            var documents = new List<Document>();
            var terms = new List<Term>();
            var occurences = new List<Occurence>();

            foreach (var file in files)
            {
                var folderIndex = file.FullName.IndexOf(DATA_FOLDER_NAME);
                var fileName = file.FullName.Substring(folderIndex, file.FullName.Length - 1 - folderIndex);
                fileName = fileName.Replace('\\', '.');

                var document = new Document() { Title = fileName, Link = file.FullName, Date = DateTime.Now };
                documents.Add(document);
                var wordsInDoc = new List<string>();

                using (var streamer = new StreamReader(file.FullName))
                {
                    var text = streamer.ReadToEnd();
                    
                    var lastIndex = 0;
                    var currentIndex = 0;

                    while (currentIndex < text.Length - 1)
                    {
                        currentIndex++;
                        if (!char.IsLetterOrDigit(text[currentIndex]) && currentIndex != 0) 
                        {
                            var length = currentIndex - lastIndex;
                            if (length != 0) {
                                var word = text.Substring(lastIndex, length).ToLower();
                                var term = CheckAndReturnTerm(word, terms);

                                if (term == null) 
                                {
                                    term = new Term(){ Value = word };
                                    terms.Add(term);
                                }

                                if (!wordsInDoc.Contains(word)) {
                                    var occurence = new Occurence(){ Document = document, Term = term};
                                    occurences.Add(occurence);
                                    wordsInDoc.Add(word);
                                    //Console.WriteLine($"Occurence: {document.Title}, {term.Value}");
                                }
                            }
                            lastIndex = currentIndex+1;
                        }
                    }
                }
            }

            Console.WriteLine("Done running through all files and directories!");

            var ctx = new SearchContext();
            ctx.Database.EnsureCreated();
            ctx.Documents.AddRange(documents);
            Console.WriteLine("Added all documents");
            ctx.Terms.AddRange(terms);
            Console.WriteLine("Added all terms");
            ctx.Occurences.AddRange(occurences);
            Console.WriteLine("Added all occurences of terms in  documents");
            ctx.SaveChanges();
            Console.WriteLine("Everything is saved in database");
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

        private static Term CheckAndReturnTerm(string value, List<Term> terms)
        {
            var term = terms.Find(t => t.Value == value);

            return term;
        }
    }
}
