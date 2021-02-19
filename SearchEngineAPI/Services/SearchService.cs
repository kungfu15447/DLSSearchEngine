using System.Collections.Generic;
using System.Linq;
using SearchEngineAPI.Context;
using SearchEngineAPI.Models;

namespace SearchEngineAPI.Services
{
    public class SearchService : ISearchService
    {
        private SearchContext _ctx;
        public SearchService(SearchContext ctx)
        {
            _ctx = ctx;
        }
        public List<Document> GetDocumentsByTerm(Term term)
        {
            var docOccurences = _ctx.Occurences.Where(oc => oc.TermId == term.TermId);
            var documents = _ctx.Documents.Where(doc => docOccurences.Any(oc => oc.DocumentId == doc.DocumentId));

            return documents.ToList();
        }
    }
}