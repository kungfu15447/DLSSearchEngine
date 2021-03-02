using System;

namespace SearchHistoryAPI.Models
{
    public class SearchStatement
    {
        public int Id { get; set; }
        public String Statement { get; set; }
        public DateTime SearchedOn { get; set; }        
    }
}