using System;

namespace SearchEngineAPI.Models
{
    public class Document
    {
        public int DocumentId { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public DateTime Date { get; set; }
    }
}