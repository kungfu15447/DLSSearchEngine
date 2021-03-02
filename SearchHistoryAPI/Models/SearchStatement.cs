using System;

namespace SearchHistoryAPI.Models
{
    public class SearchStatement
    {
        public int Id { get; set; }
        public string Statement { get; set; }
        public DateTime SearchedOn { get; set; }        
    }
}