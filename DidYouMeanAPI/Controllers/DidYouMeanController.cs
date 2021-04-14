using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DidYouMeanAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DidYouMeanAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DidYouMeanController : ControllerBase
    {
        private readonly ILogger<DidYouMeanController> _logger;
        private ISpellCheckerService _service;

        public DidYouMeanController(ILogger<DidYouMeanController> logger, ISpellCheckerService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetSynonyms([FromQuery] string term, int nAmount)
        {
            _logger.LogDebug("Poopi, stinky");
            if (string.IsNullOrEmpty(term))
            {
                return BadRequest();
            }

            var result  = await _service.GetSimilarWordsAsync(term, 1, nAmount);
            _logger.LogDebug("stinky poo");
            return Ok(result);
        }
    }
}
