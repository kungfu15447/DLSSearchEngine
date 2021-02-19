namespace SearchEngineAPI.Models
{
    public class Occurence
    {
        public int DocumentId { get; set; }
        public Document Document { get; set; }
        public int TermId { get; set; }
        public Term Term { get; set; }
    }
}