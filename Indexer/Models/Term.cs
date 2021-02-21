using System;
using System.Collections.Generic;

namespace Indexer.Models
{
    public class Term
    {
        public int TermId { get; set; }
        public string Value { get; set; }
        public List<Occurence> DocumentOccurences { get; set; }
    }
}