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
        public IActionResult GetSynonyms([FromQuery] string term)
        {
            if (String.IsNullOrEmpty(term))
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
