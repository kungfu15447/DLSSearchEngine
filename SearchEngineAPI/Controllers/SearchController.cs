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
        private ITermService _termService;

        public SearchController(ISearchService searchService, ITermService termService)
        {
            _searchService = searchService;
            _termService = termService;
        }

        [HttpGet("{value}")]
        public IActionResult GetDocumentsByTerm(string value)
        {
            Term term = _termService.GetTermByValue(value);

            if (term == null)
            {
                return new NotFoundResult();
            }

            var list = _searchService.GetDocumentsByTerm(term);

            return new OkObjectResult(list);
        }
    }
}