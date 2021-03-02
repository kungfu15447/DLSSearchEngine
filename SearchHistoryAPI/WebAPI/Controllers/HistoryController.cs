using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SearchHistoryAPI.Models;
using SearchHistoryAPI.Services;

namespace SearchHistoryAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoryController : ControllerBase
    {
        private IHistoryService _historyService;
        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var historyList = await _historyService.GetHistoryAsync();
            return Ok(historyList);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SearchStatement st)
        {
            await _historyService.AddOrUpdateStatementAsync(st);
            return Ok(st);
        }

        [HttpDelete("{statementId}")]
        public async Task<IActionResult> Delete(int statementId)
        {
            var statement = await _historyService.GetStatementByIdAsync(statementId);

            if (statement == null) 
            {
                return NotFound();
            }

            await _historyService.DeleteStatementAsync(statement);
            return Ok();
        }
    }
}