using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SearchEngineAPI.Models;
using SearchEngineAPI.Services;

namespace SearchEngineAPI.Controllers
{
    [ApiController]
    [Route("search")]
    public class SearchController : ControllerBase
    {
        private ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet("term")]
        public IEnumerable<Document> GetDocumentsByTerm(string term)
        {
            return _searchService.GetDocumentsByTerm(new Term());
        }
    }
}