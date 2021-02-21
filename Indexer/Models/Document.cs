using System;
using System.Collections.Generic;

namespace Indexer.Models
{
    public class Document
    {
        public int DocumentId { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public DateTime Date { get; set; }
        public List<Occurence> TermOccurences { get; set; }
    }
}