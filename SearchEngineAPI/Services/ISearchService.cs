using System.Collections.Generic;
using SearchEngineAPI.Models;

namespace SearchEngineAPI.Services
{
    public interface ISearchService
    {
        List<Document> GetDocumentsByTerm(Term term);
    }
}